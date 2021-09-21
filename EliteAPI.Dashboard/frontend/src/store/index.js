import {createStore} from "vuex";

export default createStore({
    state: {
        connection: {
            client: null,
            state: "",
            ip: window.location.hostname,
            port: 51555
        },
        catchup: {
            current: 0,
            total: 0,
            hasCaughtUp: false,
            isCatchingUp: false
        },
        eliteva: {
            progress: 0,
            inProgress: false
        },
        userprofile: null,
        sortedEvents: {},
        events: [],
        logs: [],
        cargo: null,
        market: null,
        modules: null,
        outfitting: null,
        shipyard: null,
        ship: null,
        navRoute: null,
        bindings: null,
        backpack: null,
        eliteapi: null
    },
    mutations: {
        connect() {
            this.state.connection.state = "connecting";
            console.log("ws://" + this.state.connection.ip + ":" + this.state.connection.port + "/ws")
            this.state.connection.client = new WebSocket("ws://" + this.state.connection.ip + ":" + this.state.connection.port + "/ws", "EliteAPI-app");

            setTimeout(() => {
                if (this.state.connection.client.readyState === 0) {
                    this.state.connection.client.close();
                }
            }, 15000);

            this.state.connection.client.onerror = function (error) {
                this.state.connection.state = "error";
                console.error("Websocket could not connect", error);
            };

            this.state.connection.client.onopen = () => {
                this.state.connection.state = "connected";
                send(this.state.connection.client, "auth", "frontend");
                send(this.state.connection.client, "userprofile.get", "");
            };

            this.state.connection.client.onclose = () => {
                this.state.connection.state = "closed";
                console.log("Websocket closed");
            };

            this.state.connection.client.onmessage = (compressed) => {
                let raw = compressed.data;

                let message = decompress(raw);

                let type = message.type;
                let data = message.value;

                if (this.state.catchup.isCatchingUp) {
                    this.state.catchup.current++;
                }

                switch (type) {
                    case "Event":
                        if (!this.state.sortedEvents[data.Event]) {
                            this.state.sortedEvents[data.Event] = [];
                        }

                        this.state.sortedEvents[data.Event].unshift(data);
                        this.state.events.unshift(data);
                        break;

                    case "CatchupStart":
                        this.state.catchup.total = data;
                        this.state.catchup.current = 0;
                        this.state.catchup.isCatchingUp = true;
                        this.state.catchup.hasCaughtUp = false;
                        break;

                    case "CatchupEnd":
                        this.state.catchup.isCatchingUp = false;
                        this.state.catchup.hasCaughtUp = true;
                        this.state.catchup.current = this.state.catchup.total;
                        break;

                    case "Log":
                        this.state.logs.unshift(data);
                        break;

                    case "EliteAPI":
                        this.state.eliteapi = data;
                        break;

                    case "Cargo":
                        console.log('Setting cargo to', data)
                        this.state.cargo = data;
                        break;

                    case "Market":
                        console.log('Setting market to', data)
                        this.state.market = data;
                        break;

                    case "Bindings":
                        console.log('Setting bindings to', data)
                        this.state.bindings = data;
                        break;

                    case "Backpack":
                        console.log('Setting backpack to', data)
                        this.state.backpack = data;
                        break;

                    case "Modules":
                        console.log('Setting modules to', data)
                        this.state.modules = data;
                        break;

                    case "Outfitting":
                        console.log('Setting outfitting to', data)
                        this.state.outfitting = data;
                        break;

                    case "Shipyard":
                        console.log('Setting shipyard to', data)
                        this.state.shipyard = data;
                        break;

                    case "Status":
                        console.log('Setting status to', data)
                        this.state.status = data;
                        break;

                    case "NavRoute":
                        console.log('Setting navroute to', data)
                        this.state.navRoute = data;
                        break;

                    case "UserProfile":
                        console.log('Setting userprofile to', data)
                        this.state.userprofile = data;
                        break;

                    case "EliteVA.Start":
                        console.log('Starting EliteVA install', data)
                        this.state.eliteva.progress = 0;
                        this.state.eliteva.inProgress = true;
                        break;

                    case "EliteVA.Progress":
                        console.log('Progress EliteVA install', data)
                        this.state.eliteva.progress = data;
                        this.state.eliteva.inProgress = true;
                        break;

                    case "EliteVA.Finished":
                        console.log('Finished EliteVA install', data)
                        this.state.eliteva.progress = 100;
                        this.state.eliteva.inProgress = false;
                        send(this.state.connection.client, "userprofile.get", "");
                        break;

                    default:
                        console.warn(type, data);
                        break;
                }
            };
        },

        send(context, payload) {
            console.log(payload)
            if (payload.valueOf() && payload.value != null && payload.value !== "") {
                send(this.state.connection.client, payload.type, JSON.stringify(payload.value));
            } else {
                send(this.state.connection.client, payload.type, "");
            }
        }
    },
    actions: {},
    modules: {}
});

function send(client, type, data) {
    let message = {
        type: type,
        value: data
    };

    let compressed = compress(message);
    console.log('SENDING', compressed)
    client.send(compressed);
    console.log('sent')
}

function compress(message) {
    return JSON.stringify(message);

    //
    // console.log('COMPRESSING', message)
    //
    // let json = JSON.stringify(message);
    // console.log('Json:', json)
    //
    // let bytes = new TextEncoder().encode(json);
    // console.log('Bytes:', bytes)
    //
    // let compressedBytes = pako.deflate(bytes);
    // console.log('Compressed bytes:', compressedBytes)
    //
    // let base64 = btoa(compressedBytes)
    // console.log('Base64:', base64)
    //
    // console.log(' ')
    //
    // return base64;
}

function decompress(message) {
    var object = JSON.parse(message);
    object.value = JSON.parse(object.value);
    return object;

    //
    // console.log('DECOMPRESSING', base64)
    //
    // let compressedBytes = JSON.parse(`[${atob(base64)}]`)
    // console.log('Compressed bytes:', compressedBytes)
    //
    // let bytes = pako.inflate(compressedBytes)
    // console.log('Bytes:', bytes)
    //
    // let json = new TextDecoder("utf-8").decode(bytes);
    // console.log('JSON:', json)
    //
    // return JSON.parse(json)
}