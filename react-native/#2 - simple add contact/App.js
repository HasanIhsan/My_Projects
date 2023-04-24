import React, { useState } from "react";
import {
  StyleSheet,
  View,
  Button,
  FlatList,
  Text,
  ScrollView,
} from "react-native";

import ContactInfoListItem from "./components/ContactInfoListItem";
import ContactInfonput from "./components/ContactInfonput";

export default function App() {
  const [ContactList, setContactList] = useState([]);
  const [isAddMode, setIsAddMode] = useState(false);

  const addContactInfoHandler = (ContactInfoItem) => {
    setContactList((ContactList) => [
      ...ContactList,
      { key: Math.random().toString(), value: ContactInfoItem },
    ]);
    setIsAddMode(false);
  };

  const removeContactInfoHandler = (itemId) => {
    setContactList((ContactList) => {
      return ContactList.filter((item) => item.key !== itemId);
    });
  };

  return (
    <View style={styles.screen}>
      <Text style={styles.baseText}>
        Lab4
        <Text style={styles.innerText}> h_ihsan</Text>
      </Text>

      <ContactInfonput
        visible={isAddMode}
        onCancel={() => setIsAddMode(false)}
        onAddItem={addContactInfoHandler}
      />
      <FlatList
        data={ContactList}
        renderItem={(itemData) => (
          <ContactInfoListItem
            id={itemData.item.key}
            onDelete={removeContactInfoHandler}
            item={itemData.item.value}
          />
        )}
      />
      <Button title="Add Contact" onPress={() => setIsAddMode(true)} />
    </View>
  );
}

const styles = StyleSheet.create({
  screen: { padding: 50 },
  baseText: {
    fontSize: 30,
    fontWeight: "bold",
  },
  innerText: {
    fontSize: 30,
    color: "red",
  },
});
