# Konatus.Teste
Teste de proficiência da empresa Konatus

### Front-end
#### Requisitos
- NodeJS versão 12

Para rodar o front, acesse o diretório abaixo:

    /Presentation/Konatus.Teste.Angular

Abra a terminal e execute o comando abaixo

```powershell
npm start run
```

### Back-end
Para rodar o front, acesse o diretório abaixo:

    /Application/Konatus.Teste.Application.Api

Não se esqueça de alterar a string de conexão para a do seu banco, a mesma está localizada no diretório abaixo:
    
    /Application/Konatus.Teste.Application.Api/appsettings.Development.json

Abra a terminal e execute o comando abaixo

```powershell
dotnet run
```

### Database
Caso esteja em uma máquina windows sem banco de dados, siga os passos abaixo:

- Acesse o powershell em modo admin e execute os comandos abaixo:
```powershell
# O comando a seguir instala o gerenciador de pacotes Chocolatey, por meio dele instalaremos o minikube
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
```

- Após finalizar a execução do comando acima, para evitar erros, feche e abra novamente o powershell em modo admin e execute os seguintes comandos:
```powershell
choco install minikube

minikube start

kubectl apply -f \.Infrastructure\k8s
```

Após configurado o minikube, será necessário alterar a string de conexão para o ip do minikube, para conseguir o ip dele, basta digitar o comando abaixo:

    minikube ip

Qualquer dúvida, estou disponível pelo (11) 98725-8313