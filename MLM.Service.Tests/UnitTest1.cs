using MLM.Service.Models;
using MLM.Service.Services;


namespace MLM.Service.Tests
{
  public class SalesmanServiceTests
  {
    private readonly SalesmanService salesmanService;

    public SalesmanServiceTests()
    {
      salesmanService = new SalesmanService();
    }

    [Fact]
    public void ShouldCreateGridWithCorrectRowsAndColumns()
    {
      int columns = 5;
      int rows = 4;

      var grid = salesmanService.CreatePersonGrid(columns, rows);

      Assert.Equal(columns, grid.GetLength(0));
      Assert.Equal(rows, grid.GetLength(1));
      Assert.All(grid.Cast<Person>(), person =>
      {
        Assert.False(person.IsSalesman);
      });
    }

    [Fact]
    public void ShouldReturnCorrectStatusAfterEachHour()
    {
      int columns = 3;
      int rows = 3;
      var grid = salesmanService.CreatePersonGrid(columns, rows);
      grid[0, 0].IsSalesman = true;
      int hour = 1;

      var gridPerHour = salesmanService.AddPersonsStatusAfterEachHour(grid, hour);

      Assert.NotNull(gridPerHour);
      Assert.Equal(hour, gridPerHour.Hour);
      Assert.Equal(columns * rows, gridPerHour.Persons.Count);

      Assert.Contains(gridPerHour.Persons, p => p.Position.X == 0 && p.Position.Y == 0 && p.IsSalesman);
    }

    [Fact]
    public void SimulateMLM_ShouldReturnExpectedResult()
    {
      int columns = 5;
      int rows = 5;
      int totalSimulations = 1;

      var result = salesmanService.SimulateMLM(columns, rows, totalSimulations);

      Assert.NotNull(result);
      Assert.Equal(columns, result.Columns);
      Assert.Equal(rows, result.Rows);
      Assert.NotNull(result.SimulationResult);
      Assert.NotEmpty(result.SimulationResult.SimulationRuns);
    }

    [Fact]
    public void SimulateMLM_AllPersonsInASimulationShouldBecomeSalesmen()
    {
      int columns = 3;
      int rows = 3;
      int totalSimulations = 2;

      var result = salesmanService.SimulateMLM(columns, rows, totalSimulations);

      Assert.NotNull(result);
      var finalRun = result.SimulationResult.SimulationRuns.First();
      var finalGrid = finalRun.GridPerHour.Last();
      Assert.All(finalGrid.Persons, person => Assert.True(person.IsSalesman));
    }

    [Fact]
    public void SimulateMLM_ShouldCalculateAverageHoursCorrectly()
    {
      int columns = 3;
      int rows = 3;
      int totalSimulations = 2;

      var result = salesmanService.SimulateMLM(columns, rows, totalSimulations);

      Assert.NotNull(result);
      Assert.True(result.AverageTime > 0);
      Assert.Equal(Math.Round(result.SimulationResult.SimulationRuns.Average(r => r.Hours), 1), result.AverageTime);
    }
  }
}
