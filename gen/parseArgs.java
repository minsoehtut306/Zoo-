import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.attribute.FileTime;
import java.util.ArrayList;

/**
 * @author Dolf ten Have
 * @date 13/04/2025
 *
 *       Parses a set of input parameters which are then used by the this
 *       program to
 *       Create a table that is used by makeCSV to generate lines of csv data.
 */
public class parseArgs {
	private static String _args[];
	private static int p = 1; // a pointer that keeps track of where in the _args array the program is
	private static BufferedWriter out;

	private static int fileRefs = 0; // The number of external files refferenced for data.
	private static int nSeqVarchars = 0;
	private static int maxSeqVarcharLen = 0;

	private static ArrayList<String> table; // a "buffer" array that holds the table data before it is written;
	private static ArrayList<String> csvHeader; // Contrains the column names used by the csv header
	private static ArrayList<String> files; // The path to the requested file
	private static ArrayList<String> fileType; // The type of file. 0 for file, 1 for seqFile
	private static ArrayList<String[]> cols; // The columns used by that file

	public static void main(String args[]) {
		_args = args;
		table = new ArrayList<String>();
		csvHeader = new ArrayList<String>();
		files = new ArrayList<String>();
		fileType = new ArrayList<String>();
		cols = new ArrayList<String[]>();
		readHeaderNames();
		createTable();
		writeTable();
		System.out.println("parseArgs: Done.");
	}

	/**
	 * Collects the names of the columns of the csv data
	 */
	private static void readHeaderNames() {
		boolean readAllNames = false;
		while (!readAllNames) {
			if (_args[p].substring(0, 1).compareTo("-") == 0) {
				readAllNames = true;
			} else {
				csvHeader.add(_args[p]);
				p++;
			}
		}
	}

	/**
	 * Selects the argument type and passes it on to the matching method for
	 * processing
	 */
	private static void createTable() {
		System.out.println("parseArgs: Making Table");
		while (p < _args.length) {
			switch (_args[p]) {
				// varchar
				case "-v":
					varchar();
					break;
				// integer
				case "-i":
					int_();
					break;
				// date
				case "-d":
					date();
					break;
				// time
				case "-t":
					time();
					break;
				// file
				case "-f":
					file();
					break;
				// double
				case "-o":
					double_();
					break;
				case "-I":
					seqInt_();
					break;
				case "-V":
					seqVarchar();
					break;
				case "-F":
					seqFile();
					break;
				case "-T":
					timeStamp();
					break;
				case "-h":
					hex();
					break;
				case "-e":
					email();
					break;
				case "-b":
					bool();
					break;
				case "-g":
					sex();
					break;
				case "-p":
					phone();
					break;
				case "-x":
					feedInterval();
					break;
				case "-n":
					_null();
					break;
				case "-N":
					emptyStr();
					break;
				// Unrecognised argument
				default:
					System.err.println("Argument " + p + ", '" + _args[p] + "' was not in the correct format");
					System.exit(1);
					break;
			}
		}
	}

	/**
	 * Writes a head line to the table file with the size of the table ArrayList and
	 * the number of external refferences made;
	 * Then writes the content of table line for line to the file
	 */
	private static void writeTable() {
		System.out.println("parseArgs: Writing Table");
		try {
			File files_dir = new File("tables");
			if (!files_dir.exists())
				files_dir.mkdirs();
			out = new BufferedWriter(new FileWriter("tables/" + _args[0] + ".tab"));

			String head = table.size() + " " + fileRefs + " " + nSeqVarchars + " " + maxSeqVarcharLen;
			out.write(head, 0, head.length());
			out.newLine();
			out.flush();

			for (int i = 0; i < csvHeader.size() - 1; i++) {
				out.write(csvHeader.get(i));
				out.write(",");
			}
			out.write(csvHeader.get(csvHeader.size() - 1));
			out.flush();
			out.newLine();

			for (int i = 0; i < files.size(); i++) {
				out.newLine();
				out.write(files.get(i));
				out.write(",");
				out.write(fileType.get(i));
				out.write(",");
				for (int j = 0; j < cols.get(i).length - 1; j++) {
					out.write(cols.get(i)[j]);
					out.write(",");
				}
				out.write(cols.get(i)[cols.get(i).length - 1]);
				out.flush();
			}
			out.newLine();
			out.newLine();
			out.flush();

			for (int i = 0; i < table.size() - 1; i++) {
				out.write(table.get(i), 0, table.get(i).length());
				out.newLine();
				out.flush();
			}

			out.write(table.get(table.size() - 1), 0, table.get(table.size() - 1).length());
			out.flush();
			System.out.println("parseArgs: Created 'tables/" + _args[0] + ".tab'");
			out.close();

		} catch (Exception e) {
			e.printStackTrace(System.err);
			System.exit(1);
		}
	}

	/**
	 * Adds a line too the jump table which indicates type varchar and the length of
	 * the varchar
	 */
	private static void varchar() {
		table.add("0 " + _args[p + 1]);
		p += 2;
	}

	/**
	 * Adds a line to the jump table wich indicates the type int and the length of
	 * the int (0 is incremental)
	 */
	private static void int_() {
		table.add("1 " + _args[p + 1]);
		p += 2;
	}

	/**
	 * Adds a line to the jump table which indicated type date
	 */
	private static void date() {
		table.add("2");
		p++;
	}

	/**
	 * Adds a line to the jump table which indicates type time
	 */
	private static void time() {
		table.add("3");
		p++;
	}

	/**
	 * Adds a line to the jump table which indicates type file, followed by the
	 * column of the data and then the directory of the file and the
	 */
	private static void file() {
		table.add("4 " + addFile("0") + " " + _args[p + 2]);
		p += 3;
	}

	/**
	 * Adds a file to the file array
	 */
	private static int addFile(String type) {
		int row = 0;
		// TODO check if col is already being used
		// If the files list contains the file, then just add the wanted column to the
		// end of the cols array
		if (files.contains(_args[p + 1])) {
			row = files.indexOf(_args[p + 1]);
			String col[] = new String[cols.get(row).length + 1];
			col[col.length - 1] = _args[p + 2];
			System.arraycopy(cols.get(row), 0, col, 0, cols.get(row).length);
			cols.set(row, col);
		} else {
			// Otherwise add the new file
			files.add(_args[p + 1]);
			row = files.size() - 1;
			fileType.add(type);
			cols.add(new String[] { _args[p + 2] });
			fileRefs++;
		}
		return row;
	}

	/**
	 * Writes a line to the jump table which indicates the type double, followed by
	 * the length of the double and where the seperator should be
	 */
	private static void double_() {
		int a = 0;
		int b;
		try {
			a = Integer.parseInt(_args[p + 1]);
			b = Integer.parseInt(_args[p + 2]);
			a = a - b;

			if (a < 1) {
				System.err.println("parseArgs: Error. The double '" + a + " " + b
						+ "' has a delimiter our of range of the length. Please correct this.");
				System.exit(1);
			}
		} catch (Exception e) {
			e.printStackTrace(System.err);
		}
		table.add("5 " + a + " " + _args[p + 2]);
		p += 3;
	}

	/**
	 * Writes a line to the jump table which indicated type sequentia integer
	 * The next value indicates the starting value of the integer
	 */
	private static void seqInt_() {
		table.add("6 " + _args[p + 1]);
		p += 2;
	}

	/**
	 * Writes a line to the the jump table that indicates type sequential varchar
	 * The next value indicates the length of the varchar
	 */
	private static void seqVarchar() {
		table.add("7 " + _args[p + 1]);
		nSeqVarchars++;
		try {
			int i = Integer.parseInt(_args[p + 1]);
			if (i > maxSeqVarcharLen)
				maxSeqVarcharLen = i;

		} catch (Exception e) {
			e.printStackTrace(System.err);
			System.exit(1);
		}
		p += 2;
	}

	/**
	 * Writes a line to the jump table which indicates type sequential varchar
	 * The next value indicates the path/to/file followed bu the column of the data
	 */
	private static void seqFile() {
		table.add("8 " + addFile("1") + " " + _args[p + 2]);
		p += 3;
	}

	/**
	 * Writes a line to the jump table which indicates type Timestamp
	 */
	private static void timeStamp() {
		table.add("9");
		p++;
	}

	/**
	 * Writes a line to the jump table which indicates the type hex value
	 * the next value indicates the length of the hex value
	 */
	private static void hex() {
		table.add("11 " + _args[p + 1]);
		p += 2;
	}

	/**
	 * Writes a random email type that validates the requrements for an email but is
	 * made of completely random character
	 */
	private static void email() {
		table.add("12");
		p++;
	}

	/**
	 * Creates a random boolean type represented by an integer
	 */
	private static void bool() {
		table.add("13");
		p++;
	}

	/**
	 * Creates a a char that is restricted to 'M' or 'F'
	 */
	private static void sex() {
		table.add("14");
		p++;
	}

	/**
	 * Creates an emtry in the genTable that will print a random string of 7 numbers
	 * chars (0-9).
	 * This is prepended by a set of defined coutnry or number codes of common phone
	 * prefixes.
	 */
	private static void phone() {
		table.add("15");
		p++;
	}

	/**
	 * Prints a predifined number of feeding intervals for the zoo app.
	 */
	private static void feedInterval() {
		table.add("16");
		p++;
	}

	/**
	 * Prints the 'null' string.
	 */
	private static void _null() {
		table.add("17");
		p++;
	}

	/**
	 * Prints and empty string. This is the same as leaving a nothing between two
	 * commas in a csv file.
	 */
	private static void emptyStr() {
		table.add("18");
		p++;
	}

	/**
	 * A testing method to print the content of a String array
	 */
	private static void printArray(String name, String[] arr) {
		System.out.print("Arr '" + name + "'");
		if (arr != null) {
			System.out.println(" len: " + arr.length);
			System.out.print("[");
			for (int i = 0; i < arr.length - 1; i++) {
				System.out.print(arr[i]);
				System.out.print(",");
			}
			System.out.println(arr[arr.length - 1] + "]");
		} else {
			System.out.println(" is Null");
		}
	}

}
