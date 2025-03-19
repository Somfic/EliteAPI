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

#[derive(Debug, Clone)]
struct ButtonMapping {
    button: String,
    primary: Option<(String, String)>, // (device, key)
    secondary: Option<(String, String)>,
}

fn parse_keybindings(contents: &str) -> Vec<ButtonMapping> {
    let reader = BufReader::new(contents.as_bytes());
    let mut reader = Reader::from_reader(reader);
    let mut buf = Vec::new();
    let mut buttons = Vec::new();
    let mut current_button: Option<ButtonMapping> = None;

    loop {
        match reader.read_event_into(&mut buf) {
            Ok(Event::Start(ref e)) | Ok(Event::Empty(ref e)) => {
                let tag_name = String::from_utf8_lossy(e.name().as_ref()).to_string();
                let tag_lower = tag_name.to_lowercase();
                // if it's a container element and not a primary/secondary child
                if (tag_lower.ends_with("button") || tag_lower.ends_with("key"))
                    && tag_lower != "primary"
                    && tag_lower != "secondary"
                {
                    current_button = Some(ButtonMapping {
                        button: tag_name,
                        primary: None,
                        secondary: None,
                    });
                } else if tag_lower == "primary" || tag_lower == "secondary" {
                    if let Some(ref mut mapping) = current_button {
                        let mut device = String::new();
                        let mut key = String::new();
                        for attr in e.attributes().with_checks(false).flatten() {
                            let attr_name = String::from_utf8_lossy(attr.key.as_ref()).to_string();
                            let attr_value = String::from_utf8_lossy(
                                attr.unescape_value().unwrap_or_default().as_bytes(),
                            )
                            .into_owned();
                            if attr_name.to_lowercase() == "device" {
                                device = attr_value;
                            } else if attr_name.to_lowercase() == "key" {
                                key = attr_value;
                            }
                        }
                        if tag_lower == "primary" {
                            mapping.primary = if device == "{NoDevice}" {
                                None
                            } else {
                                Some((device, key))
                            };
                        } else {
                            mapping.secondary = if device == "{NoDevice}" {
                                None
                            } else {
                                Some((device, key))
                            };
                        }
                    }
                }
            }
            Ok(Event::End(ref e)) => {
                let tag_name = String::from_utf8_lossy(e.name().as_ref())
                    .to_string()
                    .to_lowercase();
                if tag_name.ends_with("button") || tag_name.ends_with("key") {
                    if let Some(mapping) = current_button.take() {
                        buttons.push(mapping);
                    }
                }
            }
            Ok(Event::Eof) => break,
            Err(e) => panic!("error at position {}: {:?}", reader.buffer_position(), e),
            _ => {}
        }
        buf.clear();
    }

    buttons
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_parse_keybindings() {
        let path = include_str!("../test_data/keybindings.binds");
        let bindings = parse_keybindings(path);

        for binding in &bindings {
            println!("{:?}", binding);
        }

        assert!(!bindings.is_empty());
        assert!(bindings[0].button == "YawLeftButton");
        assert!(bindings[0].primary.as_ref().is_none());
        assert!(bindings[0].secondary.as_ref().is_none());

        assert!(bindings[1].button == "YawRightButton");
        assert!(bindings[1]
            .primary
            .as_ref()
            .is_some_and(|p| { p.0 == "Keyboard" && p.1 == "Key_D" }));
    }
}
