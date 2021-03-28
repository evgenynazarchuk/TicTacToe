using System;
using Xunit;
using TicTacToe.BLL;
using System.Collections.Generic;
using FluentAssertions;

namespace TicTacToe.Tests
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
            var game = new TicTacToe.BLL.TicTacToe();
            game.SetUserSymbol(userSymbol);
            game.SetGameField(gameField);
            game.FindMatches().Should().BeTrue();
        }
        [Theory]
        [MemberData(nameof(NegativeData))]
        public void FindMatchesNegativeTest(char userSymbol, char[,] gameField)
        {
            var game = new TicTacToe.BLL.TicTacToe();
            game.SetUserSymbol(userSymbol);
            game.SetGameField(gameField);
            game.FindMatches().Should().BeFalse();
        }
    }
}
