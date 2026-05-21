using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PryApeERP
{
    /// <summary>
    /// Helper de validaciones con feedback visual inline (sin MessageBox feos).
    /// Muestra un Label de error debajo de cada control que falla.
    /// </summary>
    public static class ValidacionHelper
    {
        // ── Colores del tema ──────────────────────────────────────────────────
        public static readonly Color ColorError = Color.FromArgb(220, 38, 38);   // rojo
        public static readonly Color ColorOk = Color.FromArgb(16, 185, 129);  // verde
        public static readonly Color ColorBorde = Color.FromArgb(209, 213, 219); // gris neutro
        public static readonly Color ColorBordeError = Color.FromArgb(220, 38, 38);

        // ── Aplicar / quitar estado de error visual en un TextBox ─────────────
        public static void MarcarError(TextBox txt, Label lblError, string mensaje)
        {
            txt.BackColor = Color.FromArgb(254, 242, 242);
            txt.ForeColor = ColorError;
            // Panel1.Tag guarda el color de borde original — usamos Tag del label
            lblError.Text = "⚠  " + mensaje;
            lblError.ForeColor = ColorError;
            lblError.Visible = true;
        }

        public static void QuitarError(TextBox txt, Label lblError)
        {
            txt.BackColor = Color.White;
            txt.ForeColor = Color.FromArgb(17, 24, 39);
            lblError.Text = "";
            lblError.Visible = false;
        }

        public static void MarcarErrorCombo(ComboBox cmb, Label lblError, string mensaje)
        {
            cmb.BackColor = Color.FromArgb(254, 242, 242);
            lblError.Text = "⚠  " + mensaje;
            lblError.ForeColor = ColorError;
            lblError.Visible = true;
        }

        public static void QuitarErrorCombo(ComboBox cmb, Label lblError)
        {
            cmb.BackColor = Color.White;
            lblError.Text = "";
            lblError.Visible = false;
        }

        // ── Validaciones individuales ─────────────────────────────────────────

        /// <summary>Valida que el campo no esté vacío.</summary>
        public static bool Requerido(TextBox txt, Label lblError, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MarcarError(txt, lblError, $"{nombreCampo} es obligatorio.");
                return false;
            }
            QuitarError(txt, lblError);
            return true;
        }

        /// <summary>Valida email con regex básico (debe contener @ y dominio).</summary>
        public static bool Email(TextBox txt, Label lblError)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MarcarError(txt, lblError, "El email es obligatorio.");
                return false;
            }
            // Regex: algo@algo.algo
            var patron = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$", RegexOptions.IgnoreCase);
            if (!patron.IsMatch(txt.Text.Trim()))
            {
                MarcarError(txt, lblError, "Ingresá un email válido (ej: juan@mail.com).");
                return false;
            }
            QuitarError(txt, lblError);
            return true;
        }

        /// <summary>Valida que el DNI sea sólo dígitos y tenga entre 7 y 8 caracteres.</summary>
        public static bool Dni(TextBox txt, Label lblError)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                // DNI opcional: si está vacío, OK
                QuitarError(txt, lblError);
                return true;
            }
            if (!Regex.IsMatch(txt.Text.Trim(), @"^\d{7,8}$"))
            {
                MarcarError(txt, lblError, "El DNI debe tener 7 u 8 dígitos, sin letras ni puntos.");
                return false;
            }
            QuitarError(txt, lblError);
            return true;
        }

        /// <summary>Valida que el teléfono contenga sólo dígitos, espacios, +, - y ().</summary>
        public static bool Telefono(TextBox txt, Label lblError)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                QuitarError(txt, lblError);
                return true;
            }
            if (!Regex.IsMatch(txt.Text.Trim(), @"^[\d\s\+\-\(\)]{6,20}$"))
            {
                MarcarError(txt, lblError, "Teléfono inválido. Usá sólo números, +, - y paréntesis.");
                return false;
            }
            QuitarError(txt, lblError);
            return true;
        }

        /// <summary>Valida coordenada decimal entre -90/90 o -180/180.</summary>
        public static bool Coordenada(TextBox txt, Label lblError, string nombre, double min, double max)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                QuitarError(txt, lblError);
                return true;
            }
            if (!double.TryParse(txt.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double val) || val < min || val > max)
            {
                MarcarError(txt, lblError, $"{nombre} debe ser un número entre {min} y {max}.");
                return false;
            }
            QuitarError(txt, lblError);
            return true;
        }

        /// <summary>Valida que se haya seleccionado un ítem en el ComboBox.</summary>
        public static bool ComboSeleccionado(ComboBox cmb, Label lblError, string nombreCampo)
        {
            if (cmb.SelectedValue == null || cmb.SelectedIndex < 0)
            {
                MarcarErrorCombo(cmb, lblError, $"Seleccioná una {nombreCampo}.");
                return false;
            }
            QuitarErrorCombo(cmb, lblError);
            return true;
        }

        // ── Filtros KeyPress (prevenir entrada inválida en tiempo real) ────────

        /// <summary>Permite sólo dígitos en un TextBox.</summary>
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>Permite dígitos, +, -, (, ), espacio.</summary>
        public static void SoloTelefono(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && e.KeyChar != '+' && e.KeyChar != '-'
                && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != ' ')
                e.Handled = true;
        }

        /// <summary>Permite dígitos, punto y coma (para coordenadas).</summary>
        public static void SoloCoordenada(object sender, KeyPressEventArgs e)
        {
            var txt = sender as TextBox;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && e.KeyChar != '.' && e.KeyChar != ','
                && e.KeyChar != '-')
                e.Handled = true;

            // Permitir un solo punto/coma
            if ((e.KeyChar == '.' || e.KeyChar == ',') && txt != null
                && (txt.Text.Contains('.') || txt.Text.Contains(',')))
                e.Handled = true;

            // Permitir un solo guión al principio
            if (e.KeyChar == '-' && txt != null && txt.SelectionStart != 0)
                e.Handled = true;
        }
    }
}