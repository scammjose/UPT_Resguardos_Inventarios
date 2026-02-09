using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using Microsoft.Data.Sqlite;

namespace AppEscritorioUPT.Data.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        // SELECT base con JOIN para traer el nombre del tipo
        private const string BaseSelect = @"
            SELECT
                e.Id,
                e.TipoEquipoId,
                te.Nombre AS TipoNombre,
                e.Marca,
                e.Modelo,
                e.NumeroSerie,
                e.DireccionIp,
                e.MemoriaRam,
                e.Procesador,
                e.DiscoDuro,
                e.TieneLectorCd,
                e.MarcaMonitor,
                e.ModeloMonitor,
                e.SerieMonitor,
                e.MarcaTeclado,
                e.ModeloTeclado,
                e.SerieTeclado,
                e.MarcaMouse,
                e.ModeloMouse,
                e.SerieMouse,
                e.MarcaWebcam,
                e.ModeloWebcam,
                e.SerieWebcam,
                e.TipoImpresion,
                e.MacAddress,
                e.NumeroExtension,
                e.PrivilegiosLlamadas,
                e.EsPcEscritorio,
                e.EsAllInOne
            FROM Equipos e
            INNER JOIN TiposEquipos te ON te.Id = e.TipoEquipoId
        ";
        public IEnumerable<Equipo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " ORDER BY e.Id;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Equipo>();

            while (reader.Read())
            {
                lista.Add(MapEquipo(reader));
            }

            return lista;
        }

        public Equipo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " WHERE e.Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapEquipo(reader);
            }

            return null;
        }

        public void Add(Equipo equipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Equipos (
                    TipoEquipoId,
                    Marca,
                    Modelo,
                    NumeroSerie,
                    DireccionIp,
                    MemoriaRam,
                    Procesador,
                    DiscoDuro,
                    TieneLectorCd,
                    MarcaMonitor,
                    ModeloMonitor,
                    SerieMonitor,
                    MarcaTeclado,
                    ModeloTeclado,
                    SerieTeclado,
                    MarcaMouse,
                    ModeloMouse,
                    SerieMouse,
                    MarcaWebcam,
                    ModeloWebcam,
                    SerieWebcam,
                    TipoImpresion,
                    MacAddress,
                    NumeroExtension,
                    PrivilegiosLlamadas,
                    EsPcEscritorio,
                    EsAllInOne
                )
                VALUES (
                    @TipoEquipoId,
                    @Marca,
                    @Modelo,
                    @NumeroSerie,
                    @DireccionIp,
                    @MemoriaRam,
                    @Procesador,
                    @DiscoDuro,
                    @TieneLectorCd,
                    @MarcaMonitor,
                    @ModeloMonitor,
                    @SerieMonitor,
                    @MarcaTeclado,
                    @ModeloTeclado,
                    @SerieTeclado,
                    @MarcaMouse,
                    @ModeloMouse,
                    @SerieMouse,
                    @MarcaWebcam,
                    @ModeloWebcam,
                    @SerieWebcam,
                    @TipoImpresion,
                    @MacAddress,
                    @NumeroExtension,
                    @PrivilegiosLlamadas,
                    @EsPcEscritorio,
                    @EsAllInOne
                );
            ";

            AddParameters(cmd, equipo);
            cmd.ExecuteNonQuery();
        }

        public void Update(Equipo equipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Equipos
                SET
                    TipoEquipoId       = @TipoEquipoId,
                    Marca              = @Marca,
                    Modelo             = @Modelo,
                    NumeroSerie        = @NumeroSerie,
                    DireccionIp        = @DireccionIp,
                    MemoriaRam         = @MemoriaRam,
                    Procesador         = @Procesador,
                    DiscoDuro          = @DiscoDuro,
                    TieneLectorCd      = @TieneLectorCd,
                    MarcaMonitor       = @MarcaMonitor,
                    ModeloMonitor      = @ModeloMonitor,
                    SerieMonitor       = @SerieMonitor,
                    MarcaTeclado       = @MarcaTeclado,
                    ModeloTeclado      = @ModeloTeclado,
                    SerieTeclado       = @SerieTeclado,
                    MarcaMouse         = @MarcaMouse,
                    ModeloMouse        = @ModeloMouse,
                    SerieMouse         = @SerieMouse,
                    MarcaWebcam        = @MarcaWebcam,
                    ModeloWebcam       = @ModeloWebcam,
                    SerieWebcam        = @SerieWebcam,
                    TipoImpresion      = @TipoImpresion,
                    MacAddress         = @MacAddress,
                    NumeroExtension    = @NumeroExtension,
                    PrivilegiosLlamadas= @PrivilegiosLlamadas,
                    EsPcEscritorio     = @EsPcEscritorio,
                    EsAllInOne         = @EsAllInOne
                WHERE Id = @Id;
            ";

            AddParameters(cmd, equipo);
            cmd.Parameters.AddWithValue("@Id", equipo.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Equipos WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        public string? ObtenerUltimoCodigoPorAreaYAnio(string nomenclaturaArea, int anio)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            // Prefijo: UPT-REC-2026-
            cmd.CommandText = @"
                SELECT CodigoInventario
                FROM Equipos
                WHERE CodigoInventario LIKE @prefijo || '%'
                ORDER BY CodigoInventario DESC
                LIMIT 1;
            ";

            var prefijo = $"UPT-{nomenclaturaArea}-{anio}-";
            cmd.Parameters.Add(new SqliteParameter("@prefijo", prefijo));

            var result = cmd.ExecuteScalar();
            return result as string;
        }

        // ================== HELPERS ==================

        private static Equipo MapEquipo(Microsoft.Data.Sqlite.SqliteDataReader reader)
        {
            // OJO: los índices deben coincidir con el SELECT del BaseSelect
            var eq = new Equipo
            {
                Id = reader.GetInt32(0),
                TipoEquipoId = reader.GetInt32(1),
                TipoNombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                Marca = reader.IsDBNull(3) ? null : reader.GetString(3),
                Modelo = reader.IsDBNull(4) ? null : reader.GetString(4),
                NumeroSerie = reader.IsDBNull(5) ? null : reader.GetString(5),
                DireccionIp = reader.IsDBNull(6) ? null : reader.GetString(6),

                MemoriaRam = reader.IsDBNull(7) ? null : reader.GetString(7),
                Procesador = reader.IsDBNull(8) ? null : reader.GetString(8),
                DiscoDuro = reader.IsDBNull(9) ? null : reader.GetString(9),

                TieneLectorCd = !reader.IsDBNull(10) && reader.GetInt32(10) == 1,

                MarcaMonitor = reader.IsDBNull(11) ? null : reader.GetString(11),
                ModeloMonitor = reader.IsDBNull(12) ? null : reader.GetString(12),
                SerieMonitor = reader.IsDBNull(13) ? null : reader.GetString(13),

                MarcaTeclado = reader.IsDBNull(14) ? null : reader.GetString(14),
                ModeloTeclado = reader.IsDBNull(15) ? null : reader.GetString(15),
                SerieTeclado = reader.IsDBNull(16) ? null : reader.GetString(16),

                MarcaMouse = reader.IsDBNull(17) ? null : reader.GetString(17),
                ModeloMouse = reader.IsDBNull(18) ? null : reader.GetString(18),
                SerieMouse = reader.IsDBNull(19) ? null : reader.GetString(19),

                MarcaWebcam = reader.IsDBNull(20) ? null : reader.GetString(20),
                ModeloWebcam = reader.IsDBNull(21) ? null : reader.GetString(21),
                SerieWebcam = reader.IsDBNull(22) ? null : reader.GetString(22),

                TipoImpresion = reader.IsDBNull(23) ? null : reader.GetString(23),

                MacAddress = reader.IsDBNull(24) ? null : reader.GetString(24),
                NumeroExtension = reader.IsDBNull(25) ? null : reader.GetString(25),
                PrivilegiosLlamadas = reader.IsDBNull(26) ? null : reader.GetString(26),

                EsPcEscritorio = !reader.IsDBNull(27) && reader.GetInt32(27) == 1,
                EsAllInOne = !reader.IsDBNull(28) && reader.GetInt32(28) == 1
            };

            return eq;
        }

        private static void AddParameters(Microsoft.Data.Sqlite.SqliteCommand cmd, Equipo equipo)
        {
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@TipoEquipoId", equipo.TipoEquipoId);
            cmd.Parameters.AddWithValue("@Marca", (object?)equipo.Marca ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Modelo", (object?)equipo.Modelo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NumeroSerie", (object?)equipo.NumeroSerie ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DireccionIp", (object?)equipo.DireccionIp ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@MemoriaRam", (object?)equipo.MemoriaRam ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Procesador", (object?)equipo.Procesador ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DiscoDuro", (object?)equipo.DiscoDuro ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TieneLectorCd", (equipo.TieneLectorCd ?? false) ? 1 : 0);

            cmd.Parameters.AddWithValue("@MarcaMonitor", (object?)equipo.MarcaMonitor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ModeloMonitor", (object?)equipo.ModeloMonitor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerieMonitor", (object?)equipo.SerieMonitor ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@MarcaTeclado", (object?)equipo.MarcaTeclado ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ModeloTeclado", (object?)equipo.ModeloTeclado ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerieTeclado", (object?)equipo.SerieTeclado ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@MarcaMouse", (object?)equipo.MarcaMouse ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ModeloMouse", (object?)equipo.ModeloMouse ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerieMouse", (object?)equipo.SerieMouse ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@MarcaWebcam", (object?)equipo.MarcaWebcam ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ModeloWebcam", (object?)equipo.ModeloWebcam ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SerieWebcam", (object?)equipo.SerieWebcam ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@TipoImpresion", (object?)equipo.TipoImpresion ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@MacAddress", (object?)equipo.MacAddress ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NumeroExtension", (object?)equipo.NumeroExtension ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PrivilegiosLlamadas", (object?)equipo.PrivilegiosLlamadas ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@EsPcEscritorio", equipo.EsPcEscritorio ? 1 : 0);
            cmd.Parameters.AddWithValue("@EsAllInOne", equipo.EsAllInOne ? 1 : 0);
        }

    }
}
