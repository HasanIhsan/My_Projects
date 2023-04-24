import ACTIONS from "./actions";
const initialState = {
  contact: {
    name: "",
    number: "",
    contactAdded: false,
  },
};
function contactDataReducer(state = initialState, action) {
  // when an action is dispatched it will first go to actions.js,
  // from there it will then be intercepted by this reducer
  // based on the action that was dispatched it will then be
  // picked up by one of the cases in this switch statement
  // and the state will change based on the logic inside the case statement
  switch (action.type) {
    case ACTIONS.Types.ADD_CONTACT:
      // Object.assign creates a copy of the state since we never mutate the state directly
      return Object.assign({}, state, {
        // action.contact will contain our contact object that we passed from the UI and
        // assign it to our contact object held in the redux store
        contact: { ...action.contact },
      });
    case ACTIONS.Types.RESET_CONTACT:
      return Object.assign({}, state, {
        contact: initialState,
      });
    default:
      return state;
  }
}
export default contactDataReducer;
