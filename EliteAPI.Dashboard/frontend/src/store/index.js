import { createStore } from "vuex";

export default createStore({
  state: {
    connection: {
      client: null,
      ip: window.location.hostname,
      port: window.location.port
    },
    sortedEvents: {},
    events: [],
    logs: [],
    cargo: null,
    market: null,
    modules: null,
    outfitting: null,
    shipyard: null,
    ship: null,
    navroute: null
  },
  mutations: {
    connect() {
      this.state.connection.client = new WebSocket("ws://" + this.state.connection.ip + ":" + this.state.connection.port + "/ws", "EliteAPI-app");

      this.state.connection.client.onerror = function(error) {
        console.error("Websocket could not connect", error);
      };

      this.state.connection.client.onopen = () => {
        send(this.state.connection.client, "auth", "frontend");
      };

      this.state.connection.client.onclose = () => {
        console.log("Websocket closed");
      };

      this.state.connection.client.onmessage = (compressed) => {
        let raw = compressed.data;

        let messages = decompress(raw);

        messages.forEach(message => {
          let type = message.type;
          let data = message.value;

          switch (type) {
            case "Event":
              if (!this.state.sortedEvents[data.Event]) {
                this.state.sortedEvents[data.Event] = [];
              }

              this.state.sortedEvents[data.Event].unshift(data);
              this.state.events.unshift(data);
              break;

            case "Log":
              this.state.logs.unshift(data);
              break;

            case "Cargo":
              this.state.cargo = data;
              break;

            case "Market":
              this.state.market = data;
              break;

            case "Modules":
              this.state.modules = data;
              break;

            case "Outfitting":
              this.state.outfitting = data;
              break;

            case "Shipyard":
              this.state.shipyard = data;
              break;

            case "Status":
              this.state.status = data;
              break;

            case "NavRoute":
              this.state.navroute = data;
              break;

            default:
              console.warn(type, data)
          }
        });
      };
    },

    send(type, data) {
      send(this.state.connection.client, type, data);
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

  let compressed = compress([message]);
  client.send(compressed);
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
  var objects = JSON.parse(message);

  objects.forEach(x => {
    x.value = JSON.parse(x.value)
  })

  return objects;
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