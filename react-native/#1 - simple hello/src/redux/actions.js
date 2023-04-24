// define your action types
const Types = {
  ADD_CONTACT: "ADD_CONTACT",
  RESET_CONTACT: "RESET_CONTACT",
};
// this is the function that you will call dispatch() on
// when you dispatch the action, the object retruned will
// be intercepted by the reducer we set up
function addContact(contact) {
  // this is the data used in the reducer
  return { type: Types.ADD_CONTACT, contact };
}
function resetContact() {
  return { type: Types.RESET_CONTACT };
}
export default {
  addContact,
  resetContact,
  Types,
};
