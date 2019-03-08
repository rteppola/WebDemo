import React, { Component } from 'react';

class LähetysNappi extends Component {
    lisääasiakas() {
        alert("Nappia klikattu!");
    };

  render() {
    return (
        <div>
            <p></p>
                <button onClick={this.lisääasiakas}type="button" class="btn btn-primary">Lisää uusi asiakas tietokantaan</button>
            <p></p>
        </div>
    );
  }
}

export default LähetysNappi;	