﻿//------------------------------------------------------------------------------------
// <copyright file="TimeBasedOtpGeneratorTests.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace OathNet.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using OathNet;

    public class TimeBasedOtpGeneratorTests
    {
        [Test]
        public void GenerateOtp_without_hmac_returns_SHA1_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            DateTime dt;
            dt = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
        }

        [Test]
        public void GenerateOtp_without_hmac_returns_SHA1_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            DateTime dt;
            dt = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
            dt = new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc);
            this.TestSHA1AndAssert(key, 8, dt, this.GetOtpWithImplicitHMAC(key, 8, dt));
        }

        [Test]
        public void GenerateOtp_returns_SHA1_reference_results_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30
            };

            this.TestSHA1AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "94287082");
            this.TestSHA1AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "07081804");
            this.TestSHA1AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "14050471");
            this.TestSHA1AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "89005924");
            this.TestSHA1AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "69279037");
            this.TestSHA1AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "65353130");
        }

        [Test]
        public void GenerateOtp_returns_SHA1_reference_results_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930";

            this.TestSHA1AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "94287082");
            this.TestSHA1AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "07081804");
            this.TestSHA1AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "14050471");
            this.TestSHA1AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "89005924");
            this.TestSHA1AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "69279037");
            this.TestSHA1AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "65353130");
        }

        [Test]
        public void GenerateOtp_returns_SHA256_reference_results_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32
            };

            this.TestSHA256AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "46119246");
            this.TestSHA256AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "68084774");
            this.TestSHA256AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "67062674");
            this.TestSHA256AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "91819424");
            this.TestSHA256AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "90698825");
            this.TestSHA256AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "77737706");
        }

        [Test]
        public void GenerateOtp_returns_SHA256_reference_results_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930" + "313233343536373839303132";

            this.TestSHA256AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "46119246");
            this.TestSHA256AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "68084774");
            this.TestSHA256AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "67062674");
            this.TestSHA256AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "91819424");
            this.TestSHA256AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "90698825");
            this.TestSHA256AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "77737706");
        }

        [Test]
        public void GenerateOtp_returns_SHA512_reference_results_with_bytearray_key()
        {
            var key = new byte[]
            {
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30,
                0x31, 0x32, 0x33, 0x34
            };

            this.TestSHA512AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "90693936");
            this.TestSHA512AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "25091201");
            this.TestSHA512AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "99943326");
            this.TestSHA512AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "93441116");
            this.TestSHA512AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "38618901");
            this.TestSHA512AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "47863826");
        }

        [Test]
        public void GenerateOtp_returns_SHA512_reference_results_with_string_key()
        {
            var key = "3132333435363738393031323334353637383930" + "3132333435363738393031323334353637383930" + "3132333435363738393031323334353637383930" + "31323334";

            this.TestSHA512AndAssert(key, 8, new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc), "90693936");
            this.TestSHA512AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 29, DateTimeKind.Utc), "25091201");
            this.TestSHA512AndAssert(key, 8, new DateTime(2005, 3, 18, 1, 58, 31, DateTimeKind.Utc), "99943326");
            this.TestSHA512AndAssert(key, 8, new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc), "93441116");
            this.TestSHA512AndAssert(key, 8, new DateTime(2033, 5, 18, 3, 33, 20, DateTimeKind.Utc), "38618901");
            this.TestSHA512AndAssert(key, 8, new DateTime(2603, 10, 11, 11, 33, 20, DateTimeKind.Utc), "47863826");
        }

        [Test]
        public void GenerateOtp_test_with_Google_Authenticator_1()
        {
            var key = "48656C6C6F21DEADBEEF"; // Base-32: JBSWY3DPEHPK3PXP

            this.TestSHA1AndAssert(key, 6, new DateTime(2011, 10, 17, 7, 49, 45, DateTimeKind.Utc), "010374");
        }

        [Test]
        public void GenerateOtp_test_with_Google_Authenticator_2()
        {
            var key = "DEADBEEF48656C6C6F21"; // Base-32: 32W3532IMVWGY3ZB

            this.TestSHA1AndAssert(key, 6, new DateTime(2011, 10, 17, 7, 52, 0, DateTimeKind.Utc), "139594");
        }

        private string GetOtpWithImplicitHMAC(byte[] key, int digits, DateTime time)
        {
            var otp = new TimeBasedOtpGenerator(key, digits);
            return otp.GenerateOtp(time);
        }

        private string GetOtpWithImplicitHMAC(string key, int digits, DateTime time)
        {
            var otp = new TimeBasedOtpGenerator(key, digits);
            return otp.GenerateOtp(time);
        }

        private void TestSHA1AndAssert(byte[] key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA1HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA1AndAssert(string key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA1HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA256AndAssert(byte[] key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA256HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA256AndAssert(string key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA256HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA512AndAssert(byte[] key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA512HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }

        private void TestSHA512AndAssert(string key, int digits, DateTime time, string expected)
        {
            var otp = new TimeBasedOtpGenerator(key, digits, new SHA512HMACAlgorithm());
            var result = otp.GenerateOtp(time);
            Assert.AreEqual(expected, result);
        }
    }
}
