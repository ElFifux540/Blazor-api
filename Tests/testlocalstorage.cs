using System.Threading.Tasks;
using Blazored.LocalStorage;
using Moq;
using Xunit;

public class LocalStorageServiceTests
{
    [Fact]
    public async Task SaveValueAsync_ShouldCallSetItemAsStringAsync()
    {
        var mockLocalStorage = new Mock<ILocalStorageService>();
        var localStorageService = new LocalStorageService(mockLocalStorage.Object);

        await localStorageService.SaveValueAsync("testKey", "testValue");

        mockLocalStorage.Verify(x => x.SetItemAsStringAsync("testKey", "testValue", default), Times.Once);
    }

    [Fact]
    public async Task GetValueAsync_ShouldReturnStoredValue()
    {
        var mockLocalStorage = new Mock<ILocalStorageService>();
        mockLocalStorage
            .Setup(x => x.GetItemAsStringAsync("testKey", default))
            .ReturnsAsync("testValue");

        var localStorageService = new LocalStorageService(mockLocalStorage.Object);

        var result = await localStorageService.GetValueAsync("testKey");

        Assert.Equal("testValue", result);
    }
}
