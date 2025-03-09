using Blazored.LocalStorage;

public class LocalStorageService
{
    private readonly ILocalStorageService _localStorage;

    public LocalStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SaveValueAsync(string key, string value)
    {
        await _localStorage.SetItemAsStringAsync(key, value);
    }

    public async Task<string?> GetValueAsync(string key)
    {
        return await _localStorage.GetItemAsStringAsync(key);
    }
}
