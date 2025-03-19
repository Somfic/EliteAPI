use quick_xml::events::{BytesStart, Event};
use quick_xml::Reader;
use std::collections::HashMap;
use std::fs::File;
use std::io::BufReader;

#[derive(Debug)]
struct Button {
    device: String,
    key: String,
}

#[derive(Debug)]
struct Binding {
    primary: Option<Button>,
    secondary: Option<Button>,
}

fn parse_button(e: &BytesStart) -> Option<Button> {
    let mut device = String::new();
    let mut key = String::new();
    for attr in e.attributes().flatten() {
        match attr.key.as_ref() {
            b"Device" => {
                device = attr
                    .unescape_value()
                    .ok()
                    .map(|v| String::from_utf8_lossy(v.as_bytes()).into_owned())
                    .unwrap_or_default()
            }
            b"Key" => {
                key = attr
                    .unescape_value()
                    .ok()
                    .map(|v| String::from_utf8_lossy(v.as_bytes()).into_owned())
                    .unwrap_or_default()
            }
            _ => {}
        }
    }
    if key.is_empty() {
        None
    } else {
        Some(Button { device, key })
    }
}

fn parse_keybindings(path: &str) -> HashMap<String, Binding> {
    let file = BufReader::new(File::open(path).expect("unable to open file"));
    let mut reader = Reader::from_reader(file);

    let mut buf = Vec::new();
    let mut map = HashMap::new();
    let mut current_binding = String::new();
    let mut current = Binding {
        primary: None,
        secondary: None,
    };

    loop {
        match reader.read_event_into(&mut buf) {
            Ok(Event::Start(ref e)) => {
                let name = e.name().as_ref().to_vec();
                let tag_bytes = name.as_ref();
                let tag = std::str::from_utf8(tag_bytes).unwrap();
                if tag.ends_with("Button") || tag.ends_with("Key") {
                    current_binding = tag.to_string();
                    current = Binding {
                        primary: None,
                        secondary: None,
                    };
                } else if tag == "Primary" || tag == "Secondary" {
                    if let Some(btn) = parse_button(e) {
                        if tag == "Primary" {
                        if tag == "Primary" {
                            current.primary = Some(btn);
                        } else {
                            current.secondary = Some(btn);
                        }
                    }
                }
            }
            Ok(Event::Empty(ref e)) => {
                let tag = std::str::from_utf8(e.name().as_ref()).unwrap();
                if tag == "Primary" || tag == "Secondary" {
                    if let Some(btn) = parse_button(e) {
                        if tag == "Primary" {
                            current.primary = Some(btn);
                        } else {
                            current.secondary = Some(btn);
                        }
                    }
                }
            }
            Ok(Event::End(ref e)) => {
                let tag = std::str::from_utf8(e.name().as_ref()).unwrap();
                if (tag.ends_with("Button") || tag.ends_with("Key")) && tag == current_binding {
                    map.insert(current_binding.clone(), current);
                    current_binding.clear();
                }
            }
            Ok(Event::Eof) => break,
            _ => {}
        }
        buf.clear();
    }
    map
}
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_parse_keybindings() {
        let path = include_str!("../test_data/keybindings.binds");
        let bindings = parse_keybindings(path);
        assert!(!bindings.is_empty());
        for (key, binding) in &bindings {
            println!("Key: {}", key);
            if let Some(primary) = &binding.primary {
                println!("  Primary: {} - {}", primary.device, primary.key);
            }
            if let Some(secondary) = &binding.secondary {
                println!("  Secondary: {} - {}", secondary.device, secondary.key);
            }
        }
    }
}
