﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Research.SEAL;

namespace Microsoft.ML.Data
{
    /// <summary>
    /// The standard Ciphertext type. The representation type of this is Ciphertext.
    /// </summary>
    public class CiphertextDataViewType : StructuredDataViewType
    {
        private static volatile CiphertextDataViewType _instance;

        /// <summary>
        /// Returns an instance of this object.
        /// </summary>
        public static CiphertextDataViewType Instance
        {
            get
            {
                return _instance ??
                    Interlocked.CompareExchange(ref _instance, new CiphertextDataViewType(), null) ??
                    _instance;
            }
        }

        private CiphertextDataViewType()
            : base(typeof(Ciphertext[]))
        {
        }

        public override bool Equals(DataViewType other)
        {
            if (other == this) return true;
            Debug.Assert(!(other is CiphertextDataViewType));
            return false;
        }

        public override string ToString() => "Ciphertext[]";
    }

    /// <summary>
    /// The standard Ciphertext type. The representation type of this is GaloisKeys.
    /// </summary>
    public class CipherGaloisKeyDataViewType : StructuredDataViewType
    {
        private static volatile CipherGaloisKeyDataViewType _instance;

        /// <summary>
        /// Returns an instance of this object.
        /// </summary>
        public static CipherGaloisKeyDataViewType Instance
        {
            get
            {
                return _instance ??
                    Interlocked.CompareExchange(ref _instance, new CipherGaloisKeyDataViewType(), null) ??
                    _instance;
            }
        }

        private CipherGaloisKeyDataViewType()
            : base(typeof(Tuple<Ciphertext[], GaloisKeys>))
        {
        }

        public override bool Equals(DataViewType other)
        {
            if (other == this) return true;
            Debug.Assert(!(other is CipherGaloisKeyDataViewType));
            return false;
        }

        public override string ToString() => "Tuple<Ciphertext[], GaloisKeys>";
    }
}
