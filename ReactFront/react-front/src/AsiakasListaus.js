import React, { Component } from 'react';

class AsiakasListaus extends Component  {

    constructor(props){
      super(props);
      console.log("AsiakasListaus.constructor");
      this.state = {ladattu: false, data: null};
    }
  
    componentDidMount() {
  
      console.log("AsiakasListaus.componentDidMount");
      let komponentti = this;
  
      //fetch muodostaa GETin jos ei optioita, muut (PUT, POST,etc.) optioilla
      //katso developer.mozilla.org ista
      fetch('https://localhost:44337/api/asiakkaat')
      .then(response => response.json())
      .then(json => {
        
        console.log("Fetch-kutsu valmis!");
        console.log(json);
  
        komponentti.setState({ladattu: true, data: json});
        console.log("SetState-rutiinia kutsuttu");
        }
       );
      
  
      console.log("AsiakasListaus.componentDidMount: fetch-kutsu tehty.");
    }
  
    render() {
      console.log("AsiakasListaus.render");
  
      if (this.state.ladattu === false){
          return(
              <div>
                <h1>Odota, ladataan tietoja...</h1>
              </div>
          );
      }
      else {

        let asiakkaat = [];
        for (let index = 0; index < this.state.data.length; index++) {
            let nimi = this.state.data[index].companyName;
            asiakkaat.push(<h3 style={{color: "orangered"}}>{nimi}</h3>);
        }
    
        return (
            <div>
               {asiakkaat}
            </div>
        );



        return (
          <div>
             {this.state.data.title}
          </div>
        );
      }
    }
  }

export default AsiakasListaus;	
