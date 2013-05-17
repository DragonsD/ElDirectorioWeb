using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsx.DirLaguna.Public.Code
{
    [Serializable]
    public class ConceptDetail
    {
        int _index;
        decimal _cantidad;
        string _concepto;
        string _conceptoId;
        decimal _precioUnitario;
        decimal _subTotal;

        public ConceptDetail(int index)
        {
            _index = index;
            _cantidad = 0;
            _concepto = string.Empty;
            _conceptoId = string.Empty;
            _precioUnitario = 0;
        }

        public int Index { get { return _index; } set { _index = value; } }
        public string Concepto { get { return _concepto; } set { _concepto = value; } }
        public decimal Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                _subTotal = CalculaSubtotal();
            }
        }

        public decimal PrecioUnitario
        {
            get { return _precioUnitario; }
            set
            {
                _precioUnitario = value;
                _subTotal = CalculaSubtotal();
            }
        }

        private decimal CalculaSubtotal()
        {
            return _cantidad * _precioUnitario;
        }

        public string ConceptoId
        {
            get
            {
                return _conceptoId;
            }
            set
            {
                _conceptoId = value;
            }
        }

        public decimal SubTotal
        {
            get { return _subTotal; }
        }
    }
}