namespace ShukailaLabs;

public partial class MainPage : ContentPage
{
    double firstNumber = 0;
    double secondNumber = 0;
    string inputStr = string.Empty;
    string operation = string.Empty;

    public MainPage()
    {
        InitializeComponent();
    }

    void UpdateDisplay()
    {
        string truncatedString = inputStr.Length > 10 ? inputStr[..10] : inputStr;
        displayLabel.Text = truncatedString;
    }

    void AppendNumber(string number)
    {
        if (inputStr == "0")
            inputStr = number;
        else
            inputStr += number;
        UpdateDisplay();
    }

    void SetOperation(string newOperation)
    {
        operation = newOperation;
        if (double.TryParse(inputStr, out double result))
        {
            firstNumber = result;
            inputStr = string.Empty;
        }
        else
        {
            IncorrectInputMsg();
        }
    }

    void EqualButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(inputStr))
        {
            secondNumber = double.Parse(inputStr);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        IncorrectInputMsg();
                    }
                    break;
            }

            if (result.ToString().Length > 13)
            {
                displayLabel.Text = result.ToString()[..13];
                inputStr = result.ToString();
            }
            else
            {
                displayLabel.Text = result.ToString();
                inputStr = result.ToString();
            }
        }
    }

    void NumberButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string number = button.Text;
            AppendNumber(number);
        }
    }

    void DivideButton_Clicked(object sender, EventArgs e) => SetOperation("/");
    void MultiplyButton_Clicked(object sender, EventArgs e) => SetOperation("*");
    void SubtractButton_Clicked(object sender, EventArgs e) => SetOperation("-");
    void AddButton_Clicked(object sender, EventArgs e) => SetOperation("+");
    void CButton_Clicked(object sender, EventArgs e)
    {
        inputStr = "0";
        operation = string.Empty;
        firstNumber = 0;
        secondNumber = 0;
        UpdateDisplay();
    }
    void PointButton_Clicked(Object sender, EventArgs e)
    {
        if (!inputStr.Contains(','))
        {
            inputStr += ",";
            UpdateDisplay();
        }
    }
    void RootButton_Clicked(Object sender, EventArgs e)
    {
        if (firstNumber >= 0)
        {
            if (double.TryParse(inputStr, out double result))
            {
                firstNumber = result;
                inputStr = string.Empty;
                firstNumber = Math.Sqrt(result);
                if (firstNumber.ToString().Length > 13)
                {
                    displayLabel.Text = firstNumber.ToString()[..13];
                    inputStr = firstNumber.ToString();
                }
                else
                {
                    displayLabel.Text = firstNumber.ToString();
                    inputStr = firstNumber.ToString();
                }
            }
            else
            {
                IncorrectInputMsg();
            }
        }
        else
        {
            IncorrectInputMsg();
        }
    }
    void SquareButton_Clicked(Object sender, EventArgs e)
    {
        if (double.TryParse(inputStr, out double result))
        {
            firstNumber = result;
            inputStr = string.Empty;
            firstNumber = Math.Pow(result, 2);
            if (firstNumber.ToString().Length > 13)
            {
                displayLabel.Text = firstNumber.ToString()[..13];
                inputStr = firstNumber.ToString();
            }
            else
            {
                displayLabel.Text = firstNumber.ToString();
                inputStr = firstNumber.ToString();
            }
        }
        else
            IncorrectInputMsg();
    }
    void NearestIntButton_Clicked(Object sender, EventArgs e)
    {
        if (double.TryParse(inputStr, out double result))
        {
            firstNumber = result;
            inputStr = string.Empty;
            firstNumber = Math.Round(result);
            displayLabel.Text = firstNumber.ToString();
            inputStr = firstNumber.ToString();

        }
        else
            IncorrectInputMsg();
    }
    void IncorrectInputMsg()
    {
        displayLabel.Text = "Incorrect input";
        inputStr = string.Empty;
    }

}