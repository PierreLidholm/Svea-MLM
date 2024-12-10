using MLM.Service.Dtos;
using MLM.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MLM.Service.Services
{
    public interface ISalesmanService
    {
        Person[,] CreatePersonGrid(int columns, int rows);
        SimulationResultDto SimulateMLM(int columns, int rows, int totalRuns);
        GridPerHour AddPersonsStatusAfterEachHour(Person[,] grid, int hour);
    }

    public class SalesmanService : ISalesmanService
    {
        private readonly Random random = new Random();

        public Person[,] CreatePersonGrid(int columns, int rows)
        {
            Person[,] grid = new Person[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    grid[i, j] = new Person
                    {
                        IsSalesman = false,
                        Position = new Position { X = i, Y = j }
                    };
                }
            }
            return grid;
        }

        public SimulationResultDto SimulateMLM(int columns, int rows, int totalRuns)
        {
            var simulationResult = new SimulationResult
            {
                SimulationRuns = new List<SimulationRun>()
            };

            int totalHours = 0;

            for (int runs = 0; runs < totalRuns; runs++)
            {
                int hours = 0;
                var persons = CreatePersonGrid(columns, rows);
                var salesmen = new List<Person>();
                var simulationRun = new SimulationRun
                {
                    GridPerHour = new List<GridPerHour>(),
                };

                // Init the first salesman in a random corner
                var corners = new List<Position>
                {
                    new Position { X = 0, Y = 0 },
                    new Position { X = 0, Y = rows - 1 },
                    new Position { X = columns - 1, Y = 0 },
                    new Position { X = columns - 1, Y = rows - 1 }
                };

                Position initialCorner = corners[random.Next(corners.Count)];
                persons[initialCorner.X, initialCorner.Y].IsSalesman = true;
                salesmen.Add(persons[initialCorner.X, initialCorner.Y]);
                simulationRun.GridPerHour.Add(AddPersonsStatusAfterEachHour(persons, hours));

                //Loop through every move of each salesman while all persons are not salesmen
                while (persons.Cast<Person>().Any(p => !p.IsSalesman))
                {
                    hours++;
                    var newSalesmen = new List<Person>();

                    foreach (var salesman in salesmen.ToList())
                    {
                        int[] dx = { -1, 1, 0, 0 };
                        int[] dy = { 0, 0, -1, 1 };

                        bool validMovement = false;
                        while (!validMovement)
                        {
                            int direction = random.Next(4);
                            int newX = salesman.Position.X + dx[direction];
                            int newY = salesman.Position.Y + dy[direction];

                            if (newX >= 0 && newX < columns && newY >= 0 && newY < rows)
                            {
                                salesman.Position.X = newX;
                                salesman.Position.Y = newY;
                                if (!persons[newX, newY].IsSalesman)
                                {
                                    persons[newX, newY].IsSalesman = true;
                                    newSalesmen.Add(persons[newX, newY]);
                                }

                                validMovement = true;
                            }
                        }
                    }

                    salesmen.AddRange(newSalesmen);

                    simulationRun.GridPerHour.Add(AddPersonsStatusAfterEachHour(persons, hours));
                }

                simulationRun.Hours = hours;
                totalHours += hours;
                simulationResult.SimulationRuns.Add(simulationRun);
            }

            simulationResult.AverageHours = Math.Round((double)totalHours / (double)totalRuns, 1);


            return new SimulationResultDto(simulationResult, simulationResult.AverageHours, columns, rows);
        }

        public GridPerHour AddPersonsStatusAfterEachHour(Person[,] grid, int hour)
        {
            var gridPerHour = new GridPerHour() { Persons = new List<Person>(), Hour = hour };
            
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    gridPerHour.Persons.Add(new Person
                    {
                        IsSalesman = grid[i, j].IsSalesman,
                        Position = new Position
                        {
                            X = grid[i, j].Position.X,
                            Y = grid[i, j].Position.Y
                        }
                    });
                }
            }
            return gridPerHour;
        }
    }
}
