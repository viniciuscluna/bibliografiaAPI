# Bibliografia - API
Api desenvolvida em Net Core 3, com teste unitário e persisitencia de dados via SqLite (Não necessita de hospedagem do bando de dados)

# Execução
Basta iniciar o projeto e fazer consultar pelos seguintes endpoints:
- GET - https://localhost:44356/api/Name - Consulta todas as bibliografias persistidas;
- POST - https://localhost:44356/api/Name (Body => Array de string com os nomes) - Converte as bibliografias para padronização e persiste no banco de dados;
