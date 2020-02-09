using System.Collections;
using System.Collections.Generic;

namespace Boggle.Core.Tests.Scoring.TestData
{
    public class SumPointsTestData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, new List<string> {"tea", "tree"} };
            yield return new object[] { 2, new List<string> {"tee", "I", "tree"} };
            yield return new object[] { 22, new List<string> {"again", "access", "achieve", "accurate", "tee", "me"} };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}