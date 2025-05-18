using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesKPL_KitaBelajar.Library.Model
{
    public class RekomendasiMateri
    {
        private readonly List<UserProgress> _progressList;

        public RekomendasiMateri(List<UserProgress> progressList)
        {
            // Defensive: pastikan list tidak null
            _progressList = progressList ?? new List<UserProgress>();
        }

        public List<string> GetRekomendasi()
        {
            var rekomendasi = new List<string>();

            foreach (var progress in _progressList)
            {
                // Defensive: validasi setiap data
                if (string.IsNullOrEmpty(progress.NamaMateri))
                    continue;

                if (progress.Nilai < 66) // batas lulus 66
                {
                    rekomendasi.Add(progress.NamaMateri);
                }
            }

            return rekomendasi;
        }
    }
}
