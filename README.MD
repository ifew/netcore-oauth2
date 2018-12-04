# Example .Net Core 2 with oAuth 2

## Create Docker Client

```bash
cd client
docker build -t ui_server .
docker run -it -p 5000:5000 --name netcore_oauth2_ui ui_server
```

## step 1 - start oauth server

```bash
cd oauth_server
dotnet run
```

## step 2 - try client

```bash
cd client
dotnet run
```

or try with javascript on /client/jquery.html

## URL test on client
- Client Credential : http://localhost:5000/ClientCredentialJS.html
- Implicit : http://localhost:5000/Implicit.html

## Document Endpoint

```bash
http://localhost:5001/.well-known/openid-configuration
```