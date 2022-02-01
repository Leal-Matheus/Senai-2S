import React from 'react';
import './App.css';

//Componente funcional
function DataFormatada(props) {
  return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2>
}

//Componente de classe
//Define a classe clock que será chamada dentro do app
class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state = {
      //Define a propriedade date do state com o valor inicial como a data e hor daquele momento
      date : new Date()
    }
  }

  componentDidMount(){
    this.TimerId = setInterval(() => {
      this.tick()
    }, 1000);

    console.log('Eu sou o relogio ' + this.TimerId);
  }


  componentWillUnmount(){
    clearInterval(this.TimerId);
  }


  tick(){
    this.setState({
      date : new Date()
    })
  }

  ParaRelogio(){
    console.log(`Relógio ${this.TimerId} pausado`);
    clearInterval(this.TimerId);
  }

  RetomaRelogio(){
    console.log(`Relógio retomado!`);
    this.TimerId = setInterval(() => {
      this.tick()
    }, 1000);
    console.log(`Agora eu sou o relógio ` + this.TimerId)
  }



  render(){
    return (
      //JSX
      <div>
        <h1>Relogio  {this.TimerId}</h1>
        <DataFormatada date={this.state.date} />
        <button className="botaoPause" onClick={() => { this.ParaRelogio() }}>Pausar</button>
        <button className="botaoRetomar" onClick={() => { this.RetomaRelogio() }}>Retomar</button>
      </div>
    )
  }
}


//Componente funcional
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

//Declara que o componente APP pode ser utilizado fora desse escopo
export default App;