using FluentAssertions;

namespace MaLoIdentModelsTests.v1Tests;

public class CreateTimeZoneFile
{
    /// <summary>
    /// saves the German timezone to a serialized string: https://learn.microsoft.com/en-us/dotnet/standard/datetime/save-time-zones-to-an-embedded-resource#example
    /// </summary>
    [Fact]
    public void Serialized_Timezoneinfo_Is_Actual_German_Timezone()
    {
        TimeZoneInfo tzi;
        try
        {
            tzi = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
        }
        catch (TimeZoneNotFoundException)
        {
            //Assert.IsTrue(false, "You cannot use this method on your machine."); // this occurs in github actions. it's ok.
            return;
        }

        tzi.SupportsDaylightSavingTime.Should().BeTrue();
        tzi.Should().NotBeNull();
    }
}
