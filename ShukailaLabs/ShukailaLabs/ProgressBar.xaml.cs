namespace ShukailaLabs;

public partial class ProgressBar : ContentPage
{
    public ProgressBar()
    {
        InitializeComponent();
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
    }

    static CancellationTokenSource? cancelTokenSource;
    static CancellationToken token;

    private async void OnStartButtonClicked(object sender, EventArgs e)
    {
        StartButton.IsEnabled = false;
        CancelButton.IsEnabled = true;

        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;

        welcomeLabel.Text = "Calculating...";
        try
        {
            double result = await Task.Run(() => CalculateIntegral(token), token);
            welcomeLabel.Text = $"Result = {result}";
        }
        catch (OperationCanceledException)
        {
            welcomeLabel.Text = "Calculating is cancelled.";

        }
        finally
        {
            progressBar.Progress = 0;
            percentLabel.Text = "0%";
            StartButton.IsEnabled = true;
            CancelButton.IsEnabled = false;
            cancelTokenSource.Dispose();
        }
    }

    private async Task<double> CalculateIntegral(CancellationToken cancellationToken)
    {
        double step = 0.00001;
        double result = 0;
        double currentProgress = 0;

        for (double x = 0; x < 1; x += step)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (x > currentProgress)
                {
                    currentProgress += 0.01;
                    progressBar.ProgressTo(currentProgress, 1, Easing.Linear);
                    percentLabel.Text = $"{(int)(currentProgress * 100)}%";
                }
            });

            result += Math.Sin(x) * step;
        }
        return result;
    }
    private void OnCancelButtonClicked(object sender, EventArgs e)
    {
        cancelTokenSource?.Cancel();
    }
}