using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;

public class ApiTests
{
    [Fact]
    public async Task FetchCurrentValue_ShouldReturnValue_WhenApiResponds()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("00:30")
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var apiService = new ApiService(httpClient);

        var result = await apiService.FetchCurrentValue();

        Assert.Equal("00:30", result);
    }

    [Fact]
    public async Task FetchCurrentValue_ShouldReturnNull_WhenApiFails()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var apiService = new ApiService(httpClient);

        var result = await apiService.FetchCurrentValue();

        Assert.Null(result);
    }
}
