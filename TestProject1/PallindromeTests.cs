using System;
using NUnit.Framework;

namespace TestProject1
{
	public class PalindromeTests
	{
		[TestCase(1,1)]
		[TestCase(10,11)]
		[TestCase(11,11)]
		[TestCase(12,22)]
		[TestCase(100,101)]
		[TestCase(299, 303)]
		public void ShouldReturnNextPalindrome(int input, int output)
		{
			Assert.AreEqual(output, PalindromeService.GetNextPalindrome(input));
		}
	}

	public static class PalindromeService
	{
		public static int GetNextPalindrome(int input)
		{
			var l = input.ToString().Length;
			var palindromeCoefficient = 0;
			for (var i = 0; i < l; i++)
			{
				palindromeCoefficient += (int)Math.Pow(10, i);
			}

			int n = (int) Math.Round(input / (double)palindromeCoefficient);

			return palindromeCoefficient * n;
		}
	}
}