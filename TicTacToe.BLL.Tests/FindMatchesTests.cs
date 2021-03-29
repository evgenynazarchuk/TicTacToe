using System;
using Xunit;
using TicTacToeApp.BLL;
using System.Collections.Generic;
using FluentAssertions;

namespace TicTacToeApp.Tests
{
    public class FindMatchesTests
    {
        public static IEnumerable<object[]> PositiveData =>
        new List<object[]>
        {
            new object[] { 'O', new char[3, 3] { { 'O', 'O', 'O' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
            new object[] { 'X', new char[3, 3] { { '\0', '\0', '\0' }, { 'X', 'X', 'X' }, { '\0', '\0', '\0' } } },
            new object[] { 'X', new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { 'X', 'X', 'X' } } },

            new object[] { 'O', new char[3, 3] { { 'O', '\0', '\0' }, { 'O', '\0', '\0' }, { 'O', '\0', '\0' } } },
            new object[] { 'X', new char[3, 3] { { '\0', 'X', '\0' }, { '\0', 'X', '\0' }, { '\0', 'X', '\0' } } },
            new object[] { 'X', new char[3, 3] { { '\0', '\0', 'X' }, { '\0', '\0', 'X' }, { '\0', '\0', 'X' } } },

            new object[] { 'O', new char[3, 3] { { 'O', '\0', '\0' }, { '\0', 'O', '\0' }, { '\0', '\0', 'O' } } },
            new object[] { 'X', new char[3, 3] { { '\0', '\0', 'X' }, { '\0', 'X', '\0' }, { 'X', '\0', '\0' } } },
        };

        public static IEnumerable<object[]> NegativeData =>
        new List<object[]>
        {
            new object[] { 'X', new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
            new object[] { 'X', new char[3, 3] { { 'X', 'O', 'X' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
            new object[] { 'X', new char[3, 3] { { 'X', '\0', '\0' }, { '\0', 'X', '\0' }, { 'X', '\0', '\0' } } },
        };

        [Theory]
        [MemberData(nameof(PositiveData))]
        public void FindMatchesPositiveTest(char userSymbol, char[,] gameField)
        {
            // Arange
            var memory = new MemoryRepository();
            var game = new TicTacToeApp.BLL.TicTacToe(memory);
            game.InitMemory(gameField: gameField);
            game.SetUserSymbol(userSymbol);
            game.SetGameField(gameField);

            // Act
            var result = game.FindMatches();

            // Assert
            result.Should().BeTrue();
        }
        [Theory]
        [MemberData(nameof(NegativeData))]
        public void FindMatchesNegativeTest(char userSymbol, char[,] gameField)
        {
            // Arange
            var memory = new MemoryRepository();
            var game = new TicTacToeApp.BLL.TicTacToe(memory);
            game.InitMemory(gameField: gameField);
            game.SetUserSymbol(userSymbol);
            game.SetGameField(gameField);

            // Act
            var result = game.FindMatches();

            // Assert
            result.Should().BeFalse();
        }
    }
}
