using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using Newtonsoft.Json;


namespace OTP_WINDOW
{

    public partial class Chap4 : Page
    {

        private readonly HttpClient httpClient = new HttpClient();
        private const string openAIUrl = "https://api.openai.com/v1/chat/completions";
        private readonly string openAIKey;

        public Chap4()
        {
            InitializeComponent();
            openAIKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrEmpty(openAIKey))
            {
                MessageBox.Show("OpenAI API 키가 설정되지 않았습니다. 환경 변수를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                AppendMessage("You: " + message);
                string response = await ReceiveMessageAsync(message);
                AppendMessage("Bot: " + response);
                MessageTextBox.Clear();
            }
        }

        private void AppendMessage(string message)
        {
            ChatTextBox.AppendText(message + Environment.NewLine);
            ChatTextBox.ScrollToEnd();
        }

        private async Task<string> ReceiveMessageAsync(string sentMessage)
        {
            try
            {
                string response = await GenerateResponseAsync(sentMessage);
                return response;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private async Task<string> GenerateResponseAsync(string input)
        {
            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = input }
                },
                max_tokens = 231, // max_tokens 값을 늘려 더 긴 응답을 받도록 설정
                temperature = 0.7
            };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAIKey);
                var response = await httpClient.PostAsync(openAIUrl, new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseBody);
                    return data.choices[0].message.content.ToString().Trim();
                }
                else
                {
                    string errorMessage = $"Error: Failed to get response from OpenAI API. Status Code: {response.StatusCode}\n" +
                                           $"Reason: {response.ReasonPhrase}\n" +
                                           $"Content: {await response.Content.ReadAsStringAsync()}";
                    return errorMessage;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
