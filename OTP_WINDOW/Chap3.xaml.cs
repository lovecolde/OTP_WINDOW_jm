using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OTP_WINDOW
{
    public partial class Chap3 : Page
    {
        private int currentQuizIndex = 0;
        private readonly string[] questions = {
            "Q 1. 오픈소스 사용 시 주의가 필요한 고려사항 3가지는?",
            "Q 2. 컴퓨터프로그램저작물이 보호 받는 지식재산권 유형4가지는?",
            "Q 3. 오픈소스와 결합·연결되었을 경우,\r\n연결된 소스코드까지 공개하는 오픈소스 라이선스 패밀리 유형은? (ex: GPL2.0)",
            "Q 4. 실행, 복사, 배포, 연구, 수정의 자유가 있으며 사용자의 자유를 보장해야하며 소프트웨어의 자유를 강조하는 것은?",
            "Q 5. 오픈소스 SW 공급망 구성요소 중 'SYSTEM' 3가지는?",
            "Q 6. 컴퓨터 프로그램 저작물이란?",
            "Q 7. 저작물의 실질적 유사성을 판단하는 보편적 방법으로 틀린 것은?\r\n" +
                "ㄱ. 추상화 과정을 통해 통합적 구성요소로 분해한다. - 단계적 구성요소\r\n" +
                "ㄴ. 여과 과정에서 보호 대상에서 제외되는 부분을 제거한다.\r\n" +
                "ㄷ. 여과 과정 후 남은 부분을 보호 대상과 비교하여 실질적 유사성을 판단한다.",
            "Q 8. 소프트웨어의 사용, 수정, 복제, 배포 등을 규제하는 규약으로\r\n이를 통해 소프트웨어를 오픈소스로 공개하는 개발자들이 사용하는 것은?",
            "Q 9. 기업이나 조직이 오픈소스 소프트웨어를 적법하고 효과적으로 활용하기 위해 따라야하는 정책, 절차 및 관행이란?",
            "Q 10. 사업 특성 상 정보시스템은 고객과 공동 소유임으로 코드가 고객에게 전달되는데 고객은 이를 3자에게 배포 가능한 것은?"

        };
        private readonly string[] answers = {
            "지식재산권, 라이선스, 보안취약점",
            "저작권, 특허권, 상표권, 영업비밀",
            "Strong Reciprocal License",
            "FreeSW",
            "소프트웨어 구성분석, CI/CD ,코드 리포지토리",
            "사람의 사상 등이 '창작성'을 보유하여 저작권을 갖는 창작물의 한 유형",
            "ㄱ",
            "오픈소스 라이선스",
            "오픈소스 컴플라이언스",
            "고객정보 시스템"


        };
        public Chap3()
        {
            InitializeComponent();
            QuizQuestion.Text = questions[currentQuizIndex];
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerTextBox.Text.Trim().Equals(answers[currentQuizIndex], System.StringComparison.OrdinalIgnoreCase))
            {
                currentQuizIndex++;
                if (currentQuizIndex < questions.Length)
                {
                    QuizQuestion.Text = questions[currentQuizIndex];
                    AnswerTextBox.Text = "";
                    FeedbackTextBlock.Text = "";
                }
                else
                {
                    QuizQuestion.Text = "모든 퀴즈를 완료했습니다!";
                    AnswerTextBox.Visibility = Visibility.Collapsed;
                    SubmitButton.Visibility = Visibility.Collapsed;
                    FeedbackTextBlock.Text = "";
                }
            }
            else
            {
                FeedbackTextBlock.Text = "정답이 아닙니다. 다시 시도하세요.";
            }
        }
    }
}