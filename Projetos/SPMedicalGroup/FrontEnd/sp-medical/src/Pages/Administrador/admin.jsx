import { useEffect, useState } from "react"
import { Link } from 'react-router-dom';
import axios from "axios"

import '../../assets/css/style.css'
import logo from '../../assets/img/Logo-SP.png'
import logo2 from '../../assets/img/Logo-SP2.png'
import sobre from '../../assets/img/sobre.png'
import agendamento from '../../assets/img/agendamento.png'
import consulta from '../../assets/img/terceiro.png'
import Login from '../../assets/img/Login.png'
import Mapa from '../../assets/img/Maps.png'

export default function Administrador(){

    const [ listaConsultas, setListaConsultas ] = useState( [] )
    const [listaMedicos, setListaMedicos] = useState([])
    const [listaPacientes, setListaPacientes] = useState([])
    const [idMedico, setIdMedico] = useState(0)
    const [idPaciente, setIdPaciente] = useState(0)
    const [dataCadastro, setDataCadastro] = useState(new Date())
    const [isLoading, setIsLoading] = useState(false)

    function consultasAdm(){
        //axios.get('http://192.168.3.106:5000/api/Consultas/', {
        axios.get('http://192.168.15.140:5000/api/Consultas/', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        } )

        .then(resposta => {
            if(resposta.status === 200){
                setListaConsultas(resposta.data)
            }
        })
        .catch(erro => console.log(erro))
    }
    
    useEffect(consultasAdm, [])
    
    function medicos() {
        //axios('http://192.168.3.106:5000/api/Medicos', {
        axios('http://192.168.15.140:5000/api/Medicos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        } )

        .then(resposta => {
            if (resposta.status === 200) {
                setListaMedicos(resposta.data)
            }
        })
        .catch(erro => console.log(erro))
    }
    
    useEffect(medicos, [])
    
    function pacientes() {
        //axios('http://192.168.3.106:5000/api/Pacientes', {
        axios('http://192.168.15.140:5000/api/Pacientes', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        } )

        .then(resposta => {
            if(resposta.status === 200) {
                setListaPacientes(resposta.data)
            }
        })
        .catch(erro => console.log(erro))
    }

    useEffect(pacientes, [])


    

    function cadastrarConsulta(event) {
        event.preventDefault();

        setIsLoading(true)
        //axios.post('http://192.168.3.106:5000/api/Consultas', {
        axios.post("http://192.168.15.140:5000/api/Consultas/",{
            IdMedico : idMedico,
            idPaciente : idPaciente,
            dataConsulta : dataCadastro
        },{
            
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
            
            
            
        } )
        .then(response => {
            if (response.status === 201) {
                setIsLoading(false)
                consultasAdm()
            }
        })
        .catch(erro => console.log(erro))
    }
   
        return (
            <div>
                <header>
                    <div className="container container_header">
                        <Link to="/" className="header_logo"><img className="logo" src={logo} alt="logo SPMed"/></Link>
                        <nav className="nav_header">
                            <Link to="/MapaBrasil" className="redirecionamento_header zoom">localizações</Link>
                            <Link to="/consultasAdm" className="redirecionamento_header zoom">agendamento</Link>
                            <Link to="/MinhasConsultas" className="redirecionamento_header zoom">consultas</Link>
                            <Link to="/Login" className="redirecionamento_header zoom">login</Link>
                        </nav>
                    </div>
                </header>
                <main>
                    <div className="container_consultas">
                        <div className="box_consultas_cadastro container">
                            <div className="box_titulo container">
                                <span>Agendar Consulta:</span>
                            </div>
                            <form onSubmit={cadastrarConsulta} className="form_cadastrar">
                                <div className="organizador_box_cadastro">
                                    <select className="input_cadastrar" name="Medico" onChange={ (evt) => setIdMedico(evt.target.value) } id="">
                                        <option value="#">Escolha um médico</option>
                                            {
                                                listaMedicos.map( (event)  => {
                                                    return(

                                                        <option key={event.idMedico} value={event.idMedico} >{event.idUsuarioNavigation.nomeUsuario} </option>
                                                        )
                                                })
                                            }                                   
                                    </select>

                                    <select className="input_cadastrar" name="Paciente" onChange={(evt) => setIdPaciente(evt.target.value)} id="">
                                        <option value="#">Escolha um paciente</option>
                                            {
                                                listaPacientes.map( (event)  => {

                                                    return(

                                                        <option key={event.idPaciente} value={event.idPaciente}>{event.idUsuarioNavigation.nomeUsuario}</option>
                                                        )
                                                })
                                            }
                                    </select>
                                </div>
                                <div className="organizador_box2_cadastro">
                                    <input className="input_cadastrar" onChange={(evt) => setDataCadastro(evt.target.value)} type="datetime-local" />
                                    
                                </div>
                                <div className="box_btnCadastrar">
                                    {isLoading && (
                                        <button
                                        type="submit"
                                        className="btn_cadastrar"
                                        disabled
                                    >
                                        Carregando...
                                    </button>
                                    )}

                                    {isLoading === false && (
                                        <button
                                        type="submit"
                                        className="btn_cadastrar"
                                    >
                                        Cadastrar
                                    </button>
                                    )}
                                </div>
                            </form>
                        </div>
                        {
                        listaConsultas.map((event) => {
                            return (

                                <div className="box_consultas container">
                                    <div className="box_titulo container">
                                        <span>Consulta: {event.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</span>
                                    </div>
                                    <div>

                                        <table className="tabela_lista">
                                            <tbody>

                                                <tr key={event.idConsulta} className="organizador_box">
                                                    <td> Medico: {event.idMedicoNavigation.idUsuarioNavigation.nomeUsuario}</td>
                                                    <td> Paciente:  {event.idPacienteNavigation.idUsuarioNavigation.nomeUsuario}</td>
                                                </tr>
                                                <tr key={event.idConsulta} className="organizador_box2">
                                                    <td> Descrição:  {event.descricaoConsulta}</td>
                                                    <td> Data:  {Intl.DateTimeFormat("pt-BR", {
                                                        year: 'numeric', month: 'short', day: 'numeric'
                                                    }).format
                                                        (new Date(event.dataConsulta))}</td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            )
                        })
                    }
                        <Link to="/Mapa" className="redirecionamento_banner zoom">
                            <article className="article_informacoes container">
                                <img className="article_2" src={Mapa}  alt="imagem Mapa"/>
                                <div className="paragrafo_article">
                                    <p>Contato:
                                        Endereço: Av. Barão Limeira, 532, São Paulo, SP </p>
                                    <p>Telefone: 11-25871230</p>
                                    <p>Email: clinicPossarle@spmedicalgroup.com.br</p>
                                </div>
                            </article>
                        </Link>
                    </div>
                </main>
                <footer>
                    <div className="container box_footer">
                    <div className="contato">
                        <p>CONTATO:</p>
                        <p>Telefone: 11-25871230</p>
                        <p>Email: clinicPossarle@spmedicalgroup.com.br</p>
                    </div>
                    <img className="logo_footer" src={logo}  alt="Logo SPMed"/>
                    </div>
                </footer>
            </div>
        )
    
}