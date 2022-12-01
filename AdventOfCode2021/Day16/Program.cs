using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(GetTotalVersion(GetPacket(GetReader("420D50000B318100415919B24E72D6509AE67F87195A3CCC518CC01197D538C3E00BC9A349A09802D258CC16FC016100660DC4283200087C6485F1C8C015A00A5A5FB19C363F2FD8CE1B1B99DE81D00C9D3002100B58002AB5400D50038008DA2020A9C00F300248065A4016B4C00810028003D9600CA4C0084007B8400A0002AA6F68440274080331D20C4300004323CC32830200D42A85D1BE4F1C1440072E4630F2CCD624206008CC5B3E3AB00580010E8710862F0803D06E10C65000946442A631EC2EC30926A600D2A583653BE2D98BFE3820975787C600A680252AC9354FFE8CD23BE1E180253548D057002429794BD4759794BD4709AEDAFF0530043003511006E24C4685A00087C428811EE7FD8BBC1805D28C73C93262526CB36AC600DCB9649334A23900AA9257963FEF17D8028200DC608A71B80010A8D50C23E9802B37AA40EA801CD96EDA25B39593BB002A33F72D9AD959802525BCD6D36CC00D580010A86D1761F080311AE32C73500224E3BCD6D0AE5600024F92F654E5F6132B49979802129DC6593401591389CA62A4840101C9064A34499E4A1B180276008CDEFA0D37BE834F6F11B13900923E008CF6611BC65BCB2CB46B3A779D4C998A848DED30F0014288010A8451062B980311C21BC7C20042A2846782A400834916CFA5B8013374F6A33973C532F071000B565F47F15A526273BB129B6D9985680680111C728FD339BDBD8F03980230A6C0119774999A09001093E34600A60052B2B1D7EF60C958EBF7B074D7AF4928CD6BA5A40208E002F935E855AE68EE56F3ED271E6B44460084AB55002572F3289B78600A6647D1E5F6871BE5E598099006512207600BCDCBCFD23CE463678100467680D27BAE920804119DBFA96E05F00431269D255DDA528D83A577285B91BCCB4802AB95A5C9B001299793FCD24C5D600BC652523D82D3FCB56EF737F045008E0FCDC7DAE40B64F7F799F3981F2490"))));
            Console.WriteLine(Evaluate(GetPacket(GetReader("420D50000B318100415919B24E72D6509AE67F87195A3CCC518CC01197D538C3E00BC9A349A09802D258CC16FC016100660DC4283200087C6485F1C8C015A00A5A5FB19C363F2FD8CE1B1B99DE81D00C9D3002100B58002AB5400D50038008DA2020A9C00F300248065A4016B4C00810028003D9600CA4C0084007B8400A0002AA6F68440274080331D20C4300004323CC32830200D42A85D1BE4F1C1440072E4630F2CCD624206008CC5B3E3AB00580010E8710862F0803D06E10C65000946442A631EC2EC30926A600D2A583653BE2D98BFE3820975787C600A680252AC9354FFE8CD23BE1E180253548D057002429794BD4759794BD4709AEDAFF0530043003511006E24C4685A00087C428811EE7FD8BBC1805D28C73C93262526CB36AC600DCB9649334A23900AA9257963FEF17D8028200DC608A71B80010A8D50C23E9802B37AA40EA801CD96EDA25B39593BB002A33F72D9AD959802525BCD6D36CC00D580010A86D1761F080311AE32C73500224E3BCD6D0AE5600024F92F654E5F6132B49979802129DC6593401591389CA62A4840101C9064A34499E4A1B180276008CDEFA0D37BE834F6F11B13900923E008CF6611BC65BCB2CB46B3A779D4C998A848DED30F0014288010A8451062B980311C21BC7C20042A2846782A400834916CFA5B8013374F6A33973C532F071000B565F47F15A526273BB129B6D9985680680111C728FD339BDBD8F03980230A6C0119774999A09001093E34600A60052B2B1D7EF60C958EBF7B074D7AF4928CD6BA5A40208E002F935E855AE68EE56F3ED271E6B44460084AB55002572F3289B78600A6647D1E5F6871BE5E598099006512207600BCDCBCFD23CE463678100467680D27BAE920804119DBFA96E05F00431269D255DDA528D83A577285B91BCCB4802AB95A5C9B001299793FCD24C5D600BC652523D82D3FCB56EF737F045008E0FCDC7DAE40B64F7F799F3981F2490"))));

            // recursively sum the versions of a packet and its content for part 1:
            int GetTotalVersion(Packet packet) =>
                packet.version + packet.packets.Select(GetTotalVersion).Sum();

            // recursively evaluate the packet and its contents based on the type tag for part 2:
            long Evaluate(Packet packet)
            {
                var parts = packet.packets.Select(Evaluate).ToArray();
                return packet.type switch
                {
                    0 => parts.Sum(),
                    1 => parts.Aggregate(1L, (acc, x) => acc * x),
                    2 => parts.Min(),
                    3 => parts.Max(),
                    4 => packet.payload, // <--- literal packet is handled uniformly
                    5 => parts[0] > parts[1] ? 1 : 0,
                    6 => parts[0] < parts[1] ? 1 : 0,
                    7 => parts[0] == parts[1] ? 1 : 0,
                    _ => throw new Exception()
                };
            }

            // convert hex string to bit sequence reader
            BitSequenceReader GetReader(string input) => new BitSequenceReader(
                new BitArray((
                    from hexChar in input
                        // get the 4 bits out of a hex char:
                    let value = Convert.ToInt32(hexChar.ToString(), 16)
                    // convert to bitmask
                    from mask in new[] { 8, 4, 2, 1 }
                    select (mask & value) != 0
                ).ToArray()
            ));

            // make sense of the bit sequence:
            Packet GetPacket(BitSequenceReader reader)
            {
                var version = reader.ReadInt(3);
                var type = reader.ReadInt(3);
                var packets = new List<Packet>();
                var payload = 0L;

                if (type == 0x4)
                {
                    // literal, payload is encoded in the following bits in 5 bit long chunks:
                    while (true)
                    {
                        var isLast = reader.ReadInt(1) == 0;
                        payload = payload * 16 + reader.ReadInt(4);
                        if (isLast)
                        {
                            break;
                        }
                    }
                }
                else if (reader.ReadInt(1) == 0)
                {
                    // operator, the next 'length' long bit sequence encodes the sub packages:
                    var length = reader.ReadInt(15);
                    var subPackages = reader.GetBitSequenceReader(length);
                    while (subPackages.Any())
                    {
                        packets.Add(GetPacket(subPackages));
                    }
                }
                else
                {
                    // operator with 'packetCount' sub packages:
                    var packetCount = reader.ReadInt(11);
                    packets.AddRange(from _ in Enumerable.Range(0, packetCount) select GetPacket(reader));
                }

                return new Packet(version, type, payload, packets.ToArray());
            }
        }

        // Reader class with convenience methods to retrieve n-bit integers and subreaders as needed
        class BitSequenceReader
        {
            private BitArray bits;
            private int ptr;

            public BitSequenceReader(BitArray bits)
            {
                this.bits = bits;
            }

            public bool Any()
            {
                return ptr < bits.Length;
            }

            public BitSequenceReader GetBitSequenceReader(int bitCount)
            {
                var bitArray = new BitArray(bitCount);
                for (var i = 0; i < bitCount; i++)
                {
                    bitArray.Set(i, bits[ptr++]);
                }
                return new BitSequenceReader(bitArray);
            }

            public int ReadInt(int bitCount)
            {
                var res = 0;
                for (var i = 0; i < bitCount; i++)
                {
                    res = res * 2 + (bits[ptr++] ? 1 : 0);
                }
                return res;
            }
        }

        // Each packet has all fields, type tag tells how to interpret the contents
        record Packet(int version, int type, long payload, Packet[] packets);

        private static void Task01()
        {
            
        }
    }
}
