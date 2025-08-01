import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.Random;

/**
 * @author Dolf ten Have
 * @date 21/04/2025
 *
 *       A container class that stores specified columns of data from a csv file
 *       for use in the random csv data project
 */
class csvFile {

	private Hashtable<Integer, Integer> col; // A translator between stored and requested column
	private Random rand;
	private ArrayList<String[]> data; // An array of lines that store the data
	private int lineCount[];

	/**
	 * Creates a new csvFile object that contains the data from the speciefied
	 * columns
	 * 
	 * @param path    the path of the file
	 * @param columns the columns of the file that you want to keep
	 */
	public csvFile(String path, int columns[]) {
		lineCount = new int[columns.length];
		rand = new Random();
		createPathTranslator(columns);
		readAllData(path, columns);
	}

	/**
	 * Creates a pointer array that translate the requested column into the locally
	 * stored column index
	 * 
	 * @param org the original column indexes of the data in the csv file
	 */
	private void createPathTranslator(int org[]) {
		col = new Hashtable<Integer, Integer>();
		for (int i = 0; i < org.length; i++) {
			col.put(org[i], i);
		}
	}

	/**
	 * Reads all all the data of the csv file and stores the specified columns in an
	 * array
	 * 
	 * @param path    path to the csv file
	 * @param columns the columns in the csv file that will be stored in this
	 *                container
	 */
	private void readAllData(String path, int columns[]) {
		try {
			BufferedReader in = new BufferedReader(new FileReader(path));
			String line;
			String split[];
			String save[];
			boolean eof = false;//End of File
			data = new ArrayList<String[]>();
			in.readLine(); //skips the header line of the file
			while (!eof) {
				line = in.readLine();
				if (line != null) {
					split = line.split(",");
					save = new String[col.size()];
					for (int i = 0; i < col.size(); i++) {
						save[i] = split[columns[i]];
					}
					data.add(save);
				} else {
					eof = true;
				}
			}
			in.close();
		} catch (Exception e) {
			e.printStackTrace(System.err);
			System.exit(1);
		}
	}

	/**
	 * Returns a random element from the speciefied row
	 * 
	 * @param column the column in the csv file the data is in
	 */
	public String getRandomLine(int column) {
		return data.get(rand.nextInt(data.size()))[col.get(column)];
	}

	/**
	 * Returns the next element from the column
	 * If the end is reached, it will restart from the top
	 *
	 * @param column the column of the data in the file
	 * @return The next item in the file from the column
	 */
	public String getNextLine(int column) {
		if (lineCount[col.get(column)] == data.size())
			lineCount[col.get(column)] = 0;
		String line = data.get(lineCount[col.get(column)])[col.get(column)];
		lineCount[col.get(column)]++;
		//printLineCount();
		//System.out.println("getNextLine: col=" + col.get(column) + " column=" + column + " lineCount="+lineCount[col.get(column)]);
		return line;
	}

	private void printLineCount(){
		System.out.print("[");
		for(int i = 0; i < lineCount.length - 1; i++){
			System.out.print(lineCount[i] + ",");	
		}
		System.out.println(lineCount[lineCount.length - 1]+"]");
	}
}
