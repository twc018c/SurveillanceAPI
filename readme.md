### 部屬設定
appsettings.json
```
// 資料庫連線字串
"ConnectionStrings": {
    "DefaultConnection": "server=localhost; port=3306; database=xxx; user=xxx; password=xxx; Persist Security Info=False; Connect Timeout=60"
},
// 前端Token
"JWT": {
    "Secret": "xxxxxxxxxxxxxxxxxxxxxx"
},
// 門禁Token
"Sciener": {
    "ID": "xxx",
    "Secret":  "xxx",
    "Username": "xxx",
    "Password": "xxx"
},
```


-----


### 資料庫
MariaDB 10.4.18 (相容MySQL 5.7+)
結構說明及測試資料於TestData目錄

-----


### 開發環境
Windows 10 專業版 (Build 19401)


### 開發工具
Visual Studio 2021 (16.9.2)
最後更新於2021-04-08


### 開發框架
.NET SDK 5.0.4


### 運行框架
.NET Runtime 5.0.4


```
https://dotnet.microsoft.com/download/dotnet/5.0
```