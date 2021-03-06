# Konatus.Teste
Teste de proficiência da empresa Konatus

## Teste prático

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

Não se esqueça de executar os em ordem scripts que estão no diretório abaixo:

    /Infrastructure/Konatus.Teste.Infrastructure.SqlServer/SQL/

Qualquer dúvida, estou disponível pelo (11) 98725-8313

## Teste teórico
### Respostas

1. Eu usaria o adapter, seguindo a imagem abaixo:

![Exemplo do padrão Adapter](https://www.programmingwithwolfgang.com/wp-content/uploads/2017/12/Adapter-pattern-UML-diagram-768x568.jpg)

2. Eu configuraria um node **Kubernetes** no qual a porta de entrada estaria uma api em cluster para conseguir atender todas as requisições sem onerar o sistema, enviaria os dados para uma fila, provavelmente um **RabbitMQ** configurado para que os dados sejam *duráveis* e na outra ponta um cluster de **worker services** desenfileirando os dados e processando o mesmo, o problema disso é que possívelmente os dados sairiam da ordem, porém, o trabalho ficaria muito (muito mesmo) mais ágil.

3. Eu trabalharia com CQRS, os commands continuariam da mesma forma, porém, as queries seriam enviadas ao cache **Redis** para otimizar a leitura, o cache seria configurado de duas maneiras, tendo um tempo de vida limite para que os dados sejam atualizados, e atualizando o cache a cada alteração nos dados, para isso poderia ser utilizado um **service bus** configurando todos os interessados pela atualização e novamente usando os **worker services**, só que dessa vez para atualizar o cache.
