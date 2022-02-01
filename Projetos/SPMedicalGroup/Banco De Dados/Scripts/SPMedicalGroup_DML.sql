USE SPMedicalGroup;
GO

INSERT INTO tipoUsuario
VALUES ('Administrador'), ('M�dico'), ('Paciente')

INSERT INTO ESPECIALIDADE
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da m�o'),('Cirurgia do aparelho digestivo'),
('Cirurgia Geral'),('Cirurgia Pedi�trica'),('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),
('Pediatria'), ('Psiquiatria');
GO

INSERT INTO INSTITUICAO (nomeFantasia, endereco, razaoSocial, CNPJ)
VALUES ('Clinica Possarle', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', 'SP Medical Group', '86.400.902/0001-30'), ('Massachusetts Clinic', '75 Francis St, Boston, MA 02115, Estados Unidos', 'MS Medical Group', '86.400.902/0001-31');
GO

INSERT INTO SITUACAO
VALUES ('REALIZADA'), ('AGENDADA'), ('Cancelada');
GO

INSERT INTO USUARIO (idTipoUsuario, nomeUsuario, emailUsuario, SenhaUsuario)
VALUES (2, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', '1234'), (2, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', '1234'), (2, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', '1234'),
	   (3, 'Ligia', 'Ligia@email.com', '1234'), (3, 'Alexandre', 'Alexandre@email.com', '1234'), (3, 'Fernando', 'Fernando@email.com', '1234'), (3, 'Henrique', 'Henrique@email.com', '1234'), (3, 'Jo�o', 'Jo�o@email.com', '1234'), (3, 'Bruno', 'Bruno@email.com', '1234'), (3, 'Mariana', 'Mariana@email.com', '1234'),
	   (1, 'Administrador', 'Adm@email.com', '1234'), (2, 'Richard Lemos', 'richard.lemos@mamedicalgroup.com.br', '1234'), (2, 'Robert Possarle', 'robert.possarle@mamedicalgroup.com.br', '1234'), (2, 'Helen Road', 'helen.road@mamedicalgroup.com.br', '1234');
GO

INSERT INTO PACIENTE(idUsuario, datanasc, RG, CPF, Telefone, enderecoPaciente)
VALUES (4, '13-10-1983', '43522543-5', '94839859000','11 3456-7654', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000'), (5, '23-07-2001', '32654345-7', '73556944057', '11 98765-6543', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'),
(6, '10-10-1978', '54636525-3', '16839338002','11 97208-4453', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'),(7, '13/10/1985', '54366362-5', '14332654765','11 3456-6543-5', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(8, '27/08/1975', '53254444-1', '91305348010', '11 7656-6377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'), (9, '21/03/1972', '54566266-7', '79799299004','11 95436-8769', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'),
(10, '05/03/2018', '54566266-8', '13771913039', NULL, 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

INSERT INTO MEDICO(idUsuario, idEspecialidade, idInstituicao, CRM)
VALUES (1, 2, 1, '54356-SP'), (2, 17, 1, '53452-SP'), (3, 16, 2, '65463-SP'), (12, 5, 2, '54356-MA'), (13, 2, 1, '53452-MA'), (14, 11, 2, '65463-MA');
GO


INSERT INTO CONSULTA(idMedico, idSituacao, idPaciente, dataConsulta, descricaoConsulta)
VALUES (3, 1, 7, '20/01/2020  15:00:00', 'A paciente est� completamente saud�vel!'), (2, 3, 2, '06/01/2020  10:00:00', 'Consulta cancelada!'), (2, 1, 3, '07/02/2020  11:00:00', 'O paciente est� saud�vel!'), (2, 1, 2, '06/02/2018  10:00:00', 'O paciente teve uma melhora, por�m, necessitar� retorno!'),
(1, 3, 4, '07/02/2019  11:00:45', 'A consulta foi cancelada!'), (3, 2, 4, '08/03/2020  15:00:00', 'A consulta foi agendada!'), (1, 2, 4, '09/03/2020  11:00:45', 'A consulta foi agendada!');
GO