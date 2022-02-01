import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Pesquisador de reposiotios do GitHub
        </p>
        <a
          className="App-link"
          href="http://localhost:3000/pesquisar"
        >
          Pesquise!
        </a>
      </header>
    </div>
  );
}

export default App;
