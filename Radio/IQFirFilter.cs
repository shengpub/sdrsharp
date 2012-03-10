﻿namespace SDRSharp.Radio
{
    public unsafe class IQFirFilter 
    {
        private readonly FirFilter _rFilter;
        private readonly FirFilter _iFilter;

        public IQFirFilter(float[] coefficients)
        {
            _rFilter = new FirFilter(coefficients);
            _iFilter = new FirFilter(coefficients);
        }

        public void Process(Complex* iq, int length)
        {
            for (var i = 0; i < length; i++)
            {
                iq[i].Real = _rFilter.Process(iq[i].Real);
                iq[i].Imag = _iFilter.Process(iq[i].Imag);
            }
        }

        public void ProcessSparseSymmetricKernel(Complex* iq, int length)
        {
            for (var i = 0; i < length; i++)
            {
                iq[i].Real = _rFilter.ProcessSparseSymmetricKernel(iq[i].Real);
                iq[i].Imag = _iFilter.ProcessSparseSymmetricKernel(iq[i].Imag);
            }
        }

        public void ProcessSymmetricKernel(Complex* iq, int length)
        {
            for (var i = 0; i < length; i++)
            {
                iq[i].Real = _rFilter.ProcessSymmetricKernel(iq[i].Real);
                iq[i].Imag = _iFilter.ProcessSymmetricKernel(iq[i].Imag);
            }
        }
    }
}
