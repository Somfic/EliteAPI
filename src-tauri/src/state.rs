pub struct AppState {
    pub reader: crate::Reader,
    pub server: crate::Server,
}

impl AppState {
    pub fn new() -> Self {
        AppState {
            reader: crate::Reader::new(),
            server: crate::Server::new(),
        }
    }
}
