using Xunit;
using Xunit.Abstractions;

namespace Admin.NET.UnitTest;

/// <summary>
/// ��Ԫ����
/// </summary>
public class UnitTest1
{
    private readonly ITestOutputHelper _output; // ��־��¼

    public UnitTest1(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(2, 1 + 1);
    }

    [Fact]
    public void ������־()
    {
        _output.WriteLine("�������������� Furion");
        Assert.NotEqual("Furion", "Fur");
    }

    /// <summary>
    /// �������������жϣ�
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 7)]
    public void ����������(int i, int j)
    {
        Assert.NotEqual(0, (i + j) % 2);
    }

    //[Fact]
    //public async Task ��������ٶ�()
    //{
    //    var rep = await "https://www.baidu.com".GetAsync();
    //    Assert.True(rep.IsSuccessStatusCode);
    //}
}