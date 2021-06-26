using System;
using Xunit;
using IIG.BinaryFlag;

namespace TestLab2
{   
    
    public class OpenTest
      {
        [Fact]
        //testing default flag
        public void TestDefault()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(3);
            Assert.True(mbf.GetFlag());
        }

    }
    public class TestConstructor
    {
        [Fact]
        public void CunstructorGetTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, true);
            Assert.True(mbf.GetFlag());

        }

        [Fact]
        public void CunstructorGetFalse()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            Assert.False(mbf.GetFlag());

        }

    }


    public class TestingLimits
    {
        ulong min = 2;
        ulong max = 17179868704;
        [Fact]
        public void TestMinLegth()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(min);
            Assert.True(mbf.GetFlag());
        }

        [Fact]
        public void TestMinLengthUnderLimit()
        {

            Assert.Throws<ArgumentOutOfRangeException>(
                  () => { MultipleBinaryFlag mbf = new MultipleBinaryFlag(min-1); });
        }

        [Fact]
        
        public void TestMaxLength()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(max);
            Assert.True(mbf.GetFlag());
        }
        [Fact]
        public void TestMaxLengthOverLimit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
              () => { MultipleBinaryFlag mbf = new MultipleBinaryFlag(max + 1); });
        }

    }
    public class TestDispose
    {
        [Fact]
        public void DisposeFlag()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            mbf.Dispose();
            Assert.Null(mbf.GetFlag());

        }
        [Fact]
        public void NewValueAfterDispose()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            mbf.Dispose();
            mbf = new MultipleBinaryFlag(2);
            Assert.True(mbf.GetFlag());
        }
    }
    public class TestResetFlag
    {
        [Fact]
        public void ResetFlags()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(3, true);
            mbf.ResetFlag(2);
            Assert.False(mbf.GetFlag());
        }
        [Fact]
        public void ResetFlagsOnminPos()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(3, true);
            mbf.ResetFlag(2);
            Assert.False(mbf.GetFlag());
        }
        [Fact]
        public void ResetAllFlags()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(3, true);
            mbf.ResetFlag(1);
            mbf.ResetFlag(2);
            Assert.False(mbf.GetFlag());
        }
        [Fact]
        public void ResetOverPosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, true);
            Assert.Throws<ArgumentOutOfRangeException>(
              () => { mbf.ResetFlag(2); });
        }
        [Fact]
        public void SetReset()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            mbf.SetFlag(1);
            mbf.ResetFlag(1);
            Assert.False(mbf.GetFlag());
        }

    }
    public class TestSetFlag
    {
        [Fact]
        public void SetFlagsGetTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            mbf.SetFlag(0);
            mbf.SetFlag(1);
            Assert.True(mbf.GetFlag());
        }
        [Fact]
        public void SetFlagsGetFalse() {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);
            mbf.SetFlag(0);
            Assert.False(mbf.GetFlag());
        }
        [Fact]
        public void SetOverPosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, true);
            Assert.Throws<ArgumentOutOfRangeException>(
              () => { mbf.SetFlag(2); });
        }
        [Fact]
        public void ResetSet()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, true);
            mbf.ResetFlag(1);
            mbf.SetFlag(1);
            Assert.True(mbf.GetFlag());
        }
    }
}
