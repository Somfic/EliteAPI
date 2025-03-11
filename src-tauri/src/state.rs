pub struct AppState {
    pub reader: crate::Reader,
}

impl AppState {
    pub fn new() -> Self {
        AppState {
            reader: crate::Reader::new(),
        }
    }
}
