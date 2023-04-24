import React from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
class ContactDetails extends React.Component {
  render() {
    return (
      <div>
        <h1>you ADDED the following contact data</h1>
        <div>
          <div>
            Contact Name (retrieved from redux): {this.props.contact.name}
          </div>
          <div>
            Contact Telephone Number (retrieved from redux):{" "}
            {this.props.contact.number}
          </div>
        </div>
      </div>
    );
  }
}
ContactDetails.propTypes = {
  contact: PropTypes.object,
};
function mapStateToProps(state) {
  return {
    contact: state.contact,
  };
}
export default connect(mapStateToProps, null)(ContactDetails);
