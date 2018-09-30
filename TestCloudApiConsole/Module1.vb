Imports System.Net.Http
Imports TestCloudApi
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()
        GetResponse()
        Console.ReadLine()
    End Sub

    Async Sub GetResponse()
        Dim res As HttpResponseMessage = Await TestCloud.MakeRequest()
        Dim responseContent = Await res.Content.ReadAsStringAsync()
        Console.WriteLine(JToken.Parse(responseContent).ToString(Formatting.Indented))
    End Sub

End Module
