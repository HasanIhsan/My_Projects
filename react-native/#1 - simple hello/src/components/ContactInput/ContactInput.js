import React from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import ACTIONS from "../../redux/actions";
import ContactDetails from "../ContactDetails/ContactDetails";
class ContactInput extends React.Component {
  // this constructor fires when the component is loads setting up our initial variables and bindings
  constructor(props) {
    super(props);
    // components internal state
    this.state = {
      name: "",
      number: "",
      contactAdded: false,
    };
    // bind custom functions to the component
    this.handleChange = this.handleChange.bind(this);
    this.addContact = this.addContact.bind(this);
    this.resetContact = this.resetContact.bind(this);
  }
  // this function will take our new values for the input and put it into its respective state value
  handleChange(event) {
    // this is the value entered into the input
    const value = event.target.value;
    // this is the name of the input which corresponds with the name in our state object
    const name = event.target.name;
    this.setState({
      [name]: value,
    });
  }
  addContact() {
    this.setState(
      {
        contactAdded: true,
      },
      // this is a call to our function we defined in mapDispatchToProps.
      () => this.props.addContact(this.state)
    );
  }
  resetContact() {
    this.setState(
      {
        name: "",
        number: "",
        contactAdded: false,
      },
      // this is a call to our function we defined in mapDispatchToProps.
      () => this.props.resetContact()
    );
  }
  // The render function is where we put all of our JSX markup. It contains what shows up on the
  screen;
  render() {
    return (
      <div>
        <h1>Please enter your contact data:</h1>
        <div>
          <div>
            Name:
            <input
              type="text"
              name="name"
              value={this.state.name}
              onChange={this.handleChange}
            ></input>
          </div>
          <div>
            Telephone Number:
            <input
              type="text"
              name="number"
              value={this.state.number}
              onChange={this.handleChange}
            ></input>
          </div>
          <button onClick={() => this.addContact()}>Add Contact</button>
        </div>
        {
          // this is equivalent to an IF statement: if contactAdded is true, display our child component
          this.state.contactAdded && (
            <div>
              {/* create the ContactDetails component */}
              <ContactDetails />
              <button onClick={() => this.resetContact()}>Reset</button>
            </div>
          )
        }
      </div>
    );
  }
}
// these props are injected through redux and are defined in the
// mapStateToProps and mapDispatchToProps function below
ContactInput.propTypes = {
  contactUpdated: PropTypes.func,
  addContact: PropTypes.func,
  resetContact: PropTypes.func,
  contact: PropTypes.object,
};
// this function is where you would put any data you want to have retrieved from
// the redux state.
function mapStateToProps(state /* this is your actual redux state tree */) {
  return {
    contact: state.contact,
  };
}
// this function is where you would define your functions that will dispatch your
// actions to update, delete, or add to your state. the functions passed to the
// dispatch() call will be from our actions.js file we created.
function mapDispatchToProps(dispatch) {
  return {
    addContact: (contact) => dispatch(ACTIONS.addContact(contact)),
    resetContact: () => dispatch(ACTIONS.resetContact()),
  };
}
// we then use connt
export default connect(mapStateToProps, mapDispatchToProps)(ContactInput);
