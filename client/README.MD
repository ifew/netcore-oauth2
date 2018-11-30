# UI Client Test

## Test Authenticate with Implicit

### Build Docker for run UI

```bash
docker build -t ui_server .
docker run -d -v /:/usr/share/nginx/html -p 5000:80 --name netcore_oauth2_ui ui_server
```

### Access to server via HTML page

```bash
http://localhost:5000/Implicit.html
```

## Test Authenticate with Client Credential

### Run .Net Console

```bash
dotnet run
```

### Result

```bash
$ dotnet run
======= Get Token ======= 

{
  "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjM0YmJkNmY3MTAyN2M1NjgwOTBiYTk2NDhhNWFmNzFiIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NDM1NTE5ODksImV4cCI6MTU0MzU1NTU4OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiLCJVc2VyLmluZm8iXSwiY2xpZW50X2lkIjoiY2xpZW50SUQiLCJzY29wZSI6WyJVc2VyLmluZm8iXX0.SNkkPrzaVuiTp1ScQ7KrcYcnjPnyCp5N1E4j7wC8IdkZIMm0GFvP0-2yJcpxILboNNTXZRrIWMBOHuBbbBWWMCLJKTi0g0KUvH5RGZv3IHTJep76vtVrcDwButz8-H0RiS3jOwadYtM3cTbCE7zPCCKqffa00-XtjtJa3tJuZSUEVuhbCEVZNiXs2GFloDv4jl6fg2X2SUzBueDQi66sNc7K_L73GrjiaYLT4CwmifftnFNax-ngufdEWwa9ha4rGBoQHwkh6v31Qm_67eDR2Fg3tJ25N9U2excg0DXzRQgUg5Eonby9Tq4EW7uapKU_5Mp9ThE7Pq-EJR8W76YHmg",
  "expires_in": 3600,
  "token_type": "Bearer"
}


======= Call API to get User Info ======= 

"Hi, I'm Few"
```