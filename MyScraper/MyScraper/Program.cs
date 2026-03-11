using HtmlAgilityPack;
using OpenAI.Chat;
using System;

string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (string.IsNullOrEmpty(apiKey)) return;

// 1. 簡單爬蟲：抓取範例網頁標題 (此處可替換為大立光相關新聞網址)
var web = new HtmlWeb();
var doc = web.Load("https://pda.yj.com.tw"); // 範例報價網
string newsText = doc.DocumentNode.SelectSingleNode("//title").InnerText;

// 2. 呼叫 ChatGPT
ChatClient client = new(model: "gpt-4o", apiKey);
ChatCompletion completion = client.CompleteChat($"請用繁體中文總結這則訊息：{newsText}");

// 3. 輸出結果（GitHub Actions 會捕捉 Console 輸出）
Console.WriteLine($"[AI 報告] {DateTime.Now}: {completion}");
