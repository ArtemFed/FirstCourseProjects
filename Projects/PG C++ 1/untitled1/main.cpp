#include <iostream>
#include <fstream>
#include <list>
#include <map>
#include <set>
#include <sstream>
#include <vector>
#include "header.h"



int main() {
    input = "input.txt";
    output = "output.txt";
    std::string command = "1";

    std::cout << "\tGraph Storage\n\n";
    do {
        std::cout << "What do you want to do?\n"
                     "    0. Exit.\n"
                     "    1. Change the location where the graph will be entered.\n"
                     "    2. Enter the graph.\n";
        int n;
        if (is_graph_received) {
            std::cout << "    3. Action with graph.\n"
                      << std::endl;
            n = GetNumberConsole(0, 3);
        } else {
            n = GetNumberConsole(0, 2);
        }
        switch (n) {
            case 1:
                HowInputGraph();
                continue;
            case 2:
                GetGraph();
                continue;
            case 3:
                ChooseActionWithGraph();
                break;
            default:
                std::cout << "Do you want to exit? Enter \"0\", else continue.\n";
                std::cin >> command;
                break;
        }
    } while (command != "0");

    std::cout << "Thank you for using me)!" << std::endl;
}


// Input
void GetGraph() {
    std::cout << "How do you want to enter and save the graph?\n"
              << "    1 - Adjacency matrix\n"
              << "    2 - Incidence matrix\n"
              << "    3 - Adjacency list\n"
              << "    4 - List of edges"
              << std::endl;

    int n = GetNumberConsole(1, 4);
    std::cout << "You have chosen:";
    switch (n) {
        case 1:
            GetGraphAdjacencyMatrix();
            break;
        case 2:
            GetGraphIncidenceMatrix();
            break;
        case 3:
            GetGraphAdjacencyList();
            break;
        case 4:
            GetGraphListEdges();
            break;
        default:
            std::cout << "Nothing?";
    }
    is_graph_received = true;
    is_degrees_calculated = false;
    is_edges_counted = false;
}

void HowInputGraph() {
    std::cout << "How do you want to input and output the graph?\n"
              << "    1 - Console\n"
              << "    2 - Text file (input.txt / output.txt)\n"
              << std::endl;
    int n = GetNumberConsole(1, 2);

    std::cout << "You have chosen:";
    if (n == 2) {
        std::cout << "Text file\n";
        console_or_file = false;
        if (cur_graph_type != 0) {
            switch (cur_graph_type) {
                case 1:
                    DisplayGraphMatrixFile(graph_adjacency_matrix.size(),
                                           graph_adjacency_matrix.size(), true);
                    break;
                case 2:
                    DisplayGraphMatrixFile(graph_incidence_matrix.size(),
                                           graph_incidence_matrix[0].size(), false);
                    break;
                case 3:
                    DisplayGraphAdjacencyList();
                    break;
                case 4:
                    DisplayListEdges();
                    break;
                default:
                    break;
            }
        }
    } else {
        std::cout << "Console\n";
        console_or_file = true;
    }
    is_degrees_calculated = false;
    is_edges_counted = false;

    std::fstream clear_file(output, std::ios::out);
    clear_file.close();
}

void ShowActionWithDegrees() {
    switch (cur_graph_type) {
        case 1:
            CalculateDegreesVerticesMatrix(graph_adjacency_matrix.size(),
                                           graph_adjacency_matrix.size(), true);
            break;
        case 2:
            CalculateDegreesVerticesMatrix(graph_incidence_matrix.size(),
                                           graph_incidence_matrix[0].size(),
                                           false);
            break;
        case 3:
            CalculateDegreesVerticesList(true);
            break;
        case 4:
            CalculateDegreesVerticesList(false);
            break;
        default:
            break;
    }
}

void ShowActionWithCountEdges() {
    switch (cur_graph_type) {
        case 1:
            CalculateCountEdgesMatrix(graph_adjacency_matrix.size(),
                                      graph_adjacency_matrix.size(), true);
            break;
        case 2:
            CalculateCountEdgesMatrix(graph_incidence_matrix.size(),
                                      graph_incidence_matrix[0].size(), false);
            break;
        case 3:
            CalculateCountEdgesList(true);
            break;
        case 4:
            CalculateCountEdgesList(false);
            break;
        default:
            break;
    }
}

void ChooseActionWithGraph() {
    std::cout << "\nWhat do you want from the graph?\n"
              << "    1 - Calculate degrees of vertices\n"
              << "    2 - Calculate count of edges\n"
              << std::endl;
    if (GetNumberConsole(1, 2) == 1) {
        ShowActionWithDegrees();
    } else {
        ShowActionWithCountEdges();
    }
}

void print_table(const size_t &n) {
    std::cout << "0 |";
    for (size_t i = 1; i <= n; ++i) {
        std::cout << i << " ";
    }
}

void GetIsOriented() {
    std::string line;
    if (console_or_file) {
        std::cout << "It will be oriented graph? (oriented - 1, Not oriented - other)\n";
        std::cin >> line;
    } else {
        std::ifstream fin(input);
        fin >> line;
        fin.close();
    }

    if (line == "1") {
        is_oriented = true;
        std::cout << "You have chosen an oriented graph\n";
    } else {
        is_oriented = false;
        std::cout << "You have chosen a NOT oriented graph\n";
    }
}

int GetNumberConsole(const int &left, const int &right) {
    bool flag;
    std::string line;
    int n;
    do {
        std::cin >> line;
        try {
            n = std::stoi(line);
            if (n < left || n > right || line.size() != 1) {
                std::cout << "You entered a number not from the range from "
                          << left << " to " << right << "!\n";
                flag = true;
            } else {
                flag = false;
            }
        }
        catch (...) {
            std::cout << "You didn't enter a number! Please enter int from " << left << " to "
                      << right << ".\n";
            flag = true;
        }
    } while (flag);
    return n;
}

void ShowExc() {
    std::string line;
    if (!console_or_file) {
        std::cout << "Change file and type something to continue.\n";
        std::getline(std::cin, line);
    }
}

int GetNumberFile(const int &left, const int &right, const int &row) {
    bool flag;
    std::string line;
    int n;
    std::ifstream fin;

    do {
        try {
            try {
                fin.open(input);
                for (size_t i = 0; i < row; ++i) {
                    fin >> line;
                }
                fin.close();
            }
            catch (...) {
                std::cout << "Problem with file! Please do something) with " << input << "\n";
                flag = true;
                ShowExc();
                continue;
            }
            n = std::stoi(line);
            if (n < left || n > right) {
                std::cout << "You entered a number not from the range from "
                          << left << " to " << right << "!\n";
                flag = true;
                ShowExc();
            } else {
                flag = false;
            }
        }
        catch (...) {
            std::cout << "You didn't enter a number! Please enter int from " << left << " to "
                      << right << ".\n";
            flag = true;
            ShowExc();

        }
    } while (flag);
    return n;
}


// Matrix Graphs
void GetGraphMatrixConsole(const int &n, const int &m, std::vector<std::vector<int>> &matrix,
                           const bool &flag) {
    std::string value;
    if (flag) {
        for (int i = 0; i < n; ++i) {
            if (console_or_file)
                std::cout << i + 1 << " |";
            for (int j = 0; j < n; ++j) {
                std::cin >> value;
                // Not zero => = 1
                if (value == "0") matrix[i][j] = 0;
                else matrix[i][j] = 1;
            }
        }
    } else {
        print_table(m);
        std::cout << "- edges numbers" << std::endl;
        for (size_t i = 0; i < n; ++i) {
            std::cout << i + 1 << " |";
            for (size_t j = 0; j < m; ++j) {
                std::cin >> value;
                if (value == "0")
                    matrix[i][j] = 0;   // Не 0 => 1
                else
                    matrix[i][j] = 1;

                if (is_oriented && value == "-1")
                    matrix[i][j] = -1;
            }
        }
    }
}

void RepairGraphMatrix(const int &n, const int &m, std::vector<std::vector<int>> &matrix,
                       const bool &flag) {
    if (flag) {
        for (size_t i = 0; i < n; ++i) {
            for (size_t j = 0; j < n; ++j) {
                // Removing loops!
                if (i == j && matrix[i][j] != 0) {
                    matrix[i][j] = 0;
                    std::cout << "This program does not work with loop graphs!\n"
                              << "Loop from " << i + 1 << " to " << j + 1 << " will be deleted!\n";
                }
                // If at least one vertex has an edge, then both connected vertices have it.
                if (!is_oriented) {
                    if (matrix[i][j] + matrix[j][i] == 1) {
                        std::cout << "The edge between vertices " << i + 1 << " and " << j + 1
                                  << " has been restored, because you chose an unoriented graph\n";
                        matrix[i][j] = 1;
                        matrix[j][i] = 1;
                    }
                }
            }
        }
    } else {
        int count_values, sum;
        for (size_t j = 0; j < m; ++j) {
            count_values = 0;
            sum = 0;
            for (size_t i = 0; i < n; ++i) {
                sum += matrix[i][j];
                if (matrix[i][j] != 0) {
                    ++count_values;
                }
            }
            if (is_oriented) {
                if (count_values != 2 || sum != 0) {
                    // Zero the column if there is an error.
                    std::cout << "There is an error in the " << j + 1
                              << "-th column, it will be zeroed! "
                                 "Because an edge has two beginnings or two ends or nothing\n";
                    for (size_t k = 0; k < n; ++k) {
                        matrix[k][j] = 0;
                    }
                }
            }
        }
    }
}

void GetGraphAdjacencyMatrix() {
    std::cout << "Adjacency matrix\n";
    GetIsOriented();
    int n;
    std::ifstream file;
    std::string line, word;
    if (console_or_file) {
        std::cout << "Enter the number of vertices:";
        n = GetNumberConsole(1, 9);
        std::cout << "I recommend entering " << n << " values per line\n";
        print_table(n);
        std::cout << "- vertex numbers" << std::endl;
    } else {
        file.open(input);
        n = GetNumberFile(1, 9, 2);
    }
    std::vector<std::vector<int>> matrix(n, std::vector<int>(n));
    if (console_or_file) {
        GetGraphMatrixConsole(n, n, matrix, true);
    } else {
        int i = 0, j = 0, z = 0;
        while (getline(file, line)) {
            if (z++ < 2) continue;
            std::cout << line << std::endl;
            std::stringstream ss(line);
            while (ss >> word && i < matrix.size()) {
                if (word == "0") matrix[i][j] = 0;
                else matrix[i][j] = 1;
                if (++j == matrix.size()) {
                    j = 0;
                    i++;
                }
            }
        }
    }
    RepairGraphMatrix(n, n, matrix, true);
    graph_adjacency_matrix = matrix;
    cur_graph_type = 1;
    if (console_or_file) {
        std::cout << "\nIn total, you entered:\n";
        DisplayGraphMatrix(n, n, true);
    } else {
        std::cout << "\n";
        DisplayGraphMatrixFile(n, n, true);
    }
}

void GetGraphIncidenceMatrix() {
    std::cout << "Incidence matrix\n";
    std::ifstream file;
    GetIsOriented();
    int n, m;
    std::string value;
    if (console_or_file) {
        std::cout << "Enter the number of vertices:";
        n = GetNumberConsole(1, 9);
        std::cout << "Enter the number of edges:";
        m = GetNumberConsole(1, n * (n - 1) / 2);
        std::cout << "I recommend entering " << m << " values per line\n";
    } else {
        file.open(input);
        n = GetNumberFile(1, 9, 2);
        m = GetNumberFile(1, n * (n - 1) / 2, 3);
    }
    std::vector<std::vector<int>> matrix(n, std::vector<int>(m));
    if (console_or_file) {
        GetGraphMatrixConsole(n, m, matrix, false);
    } else {
        int z = 0;
        for (size_t i = 0; i < n; ++i) {
            for (size_t j = 0; j < m; ++j) {
                file >> value;
                if (z++ < 3) {
                    j--;
                    continue;
                }
                if (value == "0") matrix[i][j] = 0;   // Не 0 => 1
                else matrix[i][j] = 1;
                if (is_oriented && value == "-1") matrix[i][j] = -1;
            }
        }
    }
    RepairGraphMatrix(n, m, matrix, false);
    graph_incidence_matrix = matrix;
    cur_graph_type = 2;
    if (console_or_file) {
        std::cout << "\nIn total, you entered:\n";
        DisplayGraphMatrix(n, m, false);
    } else {
        std::cout << "\n";
        DisplayGraphMatrixFile(n, m, false);
    }
}

void DisplayGraphMatrix(const size_t &row, const size_t &col, const bool &flag) {
    print_table(col);
    if (flag) {
        std::cout << "- vertex numbers" << std::endl;
    } else {
        std::cout << "- edges numbers" << std::endl;
    }
    for (size_t i = 0; i < row; ++i) {
        std::cout << i + 1 << " |";
        for (size_t j = 0; j < col; ++j) {
            if (flag) {
                std::cout << graph_adjacency_matrix[i][j] << " ";
            } else {
                std::cout << graph_incidence_matrix[i][j] << " ";
            }
        }
        std::cout << "\n";
    }
}

void DisplayGraphMatrixFile(const size_t &row, const size_t &col, const bool &flag) {
    std::string line;
    std::ofstream file(output);
    if (flag) {
        file << "Graph: Adjacency matrix:" << std::endl;
    } else {
        file << "Graph: Incidence matrix:" << std::endl;
    }

    for (size_t i = 0; i < row; ++i) {
        line = "";
        for (size_t j = 0; j < col; ++j) {
            if (flag) {
                line += std::to_string(graph_adjacency_matrix[i][j]) + " ";
            } else {
                line += std::to_string(graph_incidence_matrix[i][j]) + " ";
            }
        }
        file << line << "\n";
    }
    file.close();
}

void CalculateDegreesVerticesMatrix(const size_t &row, const size_t &col, const bool &flag) {
    if (is_degrees_calculated) return;

    std::map<int, int> dictionary;
    for (int i = 0; i < row; ++i) {
        dictionary[i + 1] = 0;
        for (int j = 0; j < col; ++j) {
            if (flag) {
                dictionary[i + 1] += graph_adjacency_matrix[i][j];
            } else {
                if (graph_incidence_matrix[i][j] == 1) {
                    ++dictionary[i + 1];
                }
            }
        }
    }
    if (console_or_file) {
        std::cout << "\nVertices degrees:" << std::endl;
        for (auto item : dictionary) {
            std::cout << item.first << " : " << item.second << "\n";
        }
    } else {
        std::ofstream file;
        file.open(output, std::ios::app);
        file << "\nVertices degrees:" << std::endl;
        for (auto item : dictionary) {
            file << item.first << " : " << item.second << "\n";
        }
        file.close();
    }
    is_degrees_calculated = true;
}

void CalculateCountEdgesMatrix(const size_t &row, const size_t &col, const bool &flag) {
    if (is_edges_counted) return;

    int count = 0;
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col; ++j) {
            if (flag) {
                count += graph_adjacency_matrix[i][j];
            } else {
                if (graph_incidence_matrix[i][j] == 1) {
                    count++;
                }
            }
        }
    }

    if (console_or_file) {
        std::cout << "\nEdges count:" << std::endl;
        if (is_oriented) {
            std::cout << count << std::endl;
        } else {
            std::cout << count / 2 << std::endl;
        }
    } else {
        std::ofstream file;
        file.open(output, std::ios::app);
        file << "\nEdges count:" << std::endl;
        if (is_oriented) {
            file << count << std::endl;
        } else {
            file << count / 2 << std::endl;
        }
        file.close();
    }
    is_edges_counted = true;
}


// List Graphs
void GetAdjacencyListConsole(const int &n, std::map<int, std::set<int>> &dict) {
    std::set<int> null_set;
    std::string line;

    std::cout << "Enter the number of vertices:";
    std::cout << "I recommend entering " << n << " values per line\n";
    std::getline(std::cin, line);

    for (int i = 1; i <= n; ++i) {
        std::cout << i << ":";
        dict[i] = null_set;
        std::getline(std::cin, line);
        for (const char &ch : line) {
            if (ch >= '1' && ch <= n + '0') {
                // Immediately avoid loops.
                if (std::find(dict[i].begin(), dict[i].end(), ch - '0') == dict[i].end()
                    && i != ch - '0') {
                    dict[i].insert(ch - '0');
                }
            }
        }
    }
}

void GetAdjacencyListFile(const int &n, std::map<int, std::set<int>> &dict) {
    std::ifstream file;
    std::set<int> null_set;
    std::string line;

    file.open(input);
    int z = 0;
    for (int i = 1; i <= n; ++i) {
        dict[i] = null_set;
        std::getline(file, line);
        if (z++ < 2) {
            i--;
            continue;
        }
        for (const char &ch : line) {
            if (ch >= '1' && ch <= n + '0') {
                // Immediately avoid loops.
                if (std::find(dict[i].begin(), dict[i].end(), ch - '0') == dict[i].end()
                    && i != ch - '0') {
                    dict[i].insert(ch - '0');
                }
            }
        }
    }
}

void GetGraphAdjacencyList() {
    std::cout << "Adjacency list\n";
    GetIsOriented();
    std::map<int, std::set<int>> dict;

    if (console_or_file) {
        GetAdjacencyListConsole(GetNumberConsole(1, 9), dict);
    } else {
        GetAdjacencyListFile(GetNumberFile(1, 9, 2), dict);
    }
    if (!is_oriented) {
        for (auto &item : dict) {
            for (const auto &vertex : item.second) {
                // If at least one vertex has an edge, then both connected vertices have it
                if (!dict[vertex].contains(item.first)) {
                    std::cout << "The edge between vertices " << item.first << " and " << vertex
                              << " has been restored\n";
                    dict[vertex].insert(item.first);
                }
            }
        }
    }
    graph_adjacency_list = dict;
    cur_graph_type = 3;
    std::cout << std::endl;
    if (console_or_file) {
        std::cout << "In total, you entered:\n";
        DisplayGraphAdjacencyList();
    } else {
        DisplayGraphAdjacencyListFile();
    }
}

void DisplayGraphAdjacencyList() {
    for (const auto &item : graph_adjacency_list) {
        if (console_or_file) {
            std::cout << item.first << ": ";
        }
        for (const auto &vert : item.second) {
            if (console_or_file) {
                std::cout << vert << " ";
            }
        }
        std::cout << "\n";
    }
}

void DisplayGraphAdjacencyListFile() {
    std::ofstream file;
    file.open(output);
    file << "Adjacency list:" << std::endl;
    for (const auto &item : graph_adjacency_list) {
        file << item.first << ": ";
        for (const auto &vert : item.second) {
            file << vert << " ";
        }
        file << "\n";
    }
}

void GetGraphListEdgesConsole(const int &n, std::set<std::pair<int, int>> &edges) {
    std::string line;

    std::cout << "Enter the number of edges:";
    std::cout << "I recommend entering " << n << " pairs per line\n";

    std::getline(std::cin, line);
    for (int i = 1; i <= n; ++i) {
        std::cout << i << ":";
        std::getline(std::cin, line);
        std::vector<int> vertex;
        for (const char &ch : line) {
            if (ch >= '1' && ch <= '9') {
                vertex.push_back(ch - '0');
            }
        }
        // Immediately avoid loops, because use "set"
        if (vertex.size() >= 2) {
            edges.insert({vertex[0], vertex[1]});
        }
    }
}

void GetGraphListEdgesFile(const int &n, std::set<std::pair<int, int>> &edges) {
    std::string line;

    std::ifstream file(input);
    int z = 0;
    for (int i = 1; i <= n; ++i) {
        std::getline(file, line);
        if (z++ < 2) {
            i--;
            continue;
        }
        std::vector<int> vertex;
        for (const char &ch : line) {
            if (ch >= '1' && ch <= '9') {
                vertex.push_back(ch - '0');
            }
        }
        // Immediately avoid loops, because use "set"
        if (vertex.size() >= 2) {
            edges.insert({vertex[0], vertex[1]});
        }
    }
}

void GetGraphListEdges() {
    std::cout << "List of edges\n";

    GetIsOriented();
    std::string line;
    std::set<std::pair<int, int>> edges;

    if (console_or_file) {
        GetGraphListEdgesConsole(GetNumberConsole(1, 9), edges);
    } else {
        GetGraphListEdgesFile(GetNumberFile(1, 9, 2), edges);
    }
    if (!is_oriented) {
        for (auto &item : edges) {
            // If at least one vertex has an edge, then both connected vertices have it
            if (!edges.contains({item.second, item.first})) {
                std::cout << "The edge between vertices " << item.first << " and " << item.second
                          << " has been restored\n";
                edges.insert({item.second, item.first});
            }
        }
    }
    graph_edges_list = edges;
    cur_graph_type = 4;

    std::cout << std::endl;
    if (console_or_file) {
        std::cout << "In total, you entered:\n";
    }
    DisplayListEdges();
}

void DisplayListEdges() {
    if (console_or_file) {
        std::cout << "List of edges:" << std::endl;
        for (const auto &item : graph_edges_list) {
            std::cout << item.first << " -> " << item.second << "\n";
        }
    } else {
        std::ofstream file;
        file.open(output);
        file << "List of edges:" << std::endl;
        for (const auto &item : graph_edges_list) {
            file << item.first << " -> " << item.second << "\n";
        }
    }
}

void CalculateDegreesVerticesList(const bool &flag) {
    if (is_degrees_calculated) return;

    std::ofstream file(output, std::ios::app);
    if (console_or_file) {
        std::cout << "\nVertices degrees:" << std::endl;
    } else {
        file << "\nVertices degrees:" << std::endl;
    }
    if (flag) {
        for (const auto &item : graph_adjacency_list) {
            if (console_or_file) {
                std::cout << item.first << " : " << item.second.size() << "\n";
            } else {
                file << item.first << " : " << item.second.size() << "\n";
            }
        }
    } else {
        std::map<int, int> dict;
        for (const auto &item : graph_edges_list) {
            dict[item.first]++;
            if (!dict.contains(item.second)) {
                dict[item.second] = 0;
            }
        }
        for (const auto &item : dict) {
            if (console_or_file) {
                std::cout << item.first << " : " << item.second << "\n";
            } else {
                file << item.first << " : " << item.second << "\n";
            }
        }
    }
    is_degrees_calculated = true;
}

void CalculateCountEdgesList(const bool &flag) {
    if (is_edges_counted) return;

    size_t count = 0;
    if (flag) {
        for (const auto &item : graph_adjacency_list) {
            count += item.second.size();
        }
    } else {
        count = graph_edges_list.size();
    }

    if (console_or_file) {
        std::cout << "\nEdges count:" << std::endl;
        if (is_oriented) {
            std::cout << count << std::endl;
        } else {
            std::cout << count / 2 << std::endl;
        }
    } else {
        std::ofstream file;
        file.open(output, std::ios::app);
        file << "\nEdges count:" << std::endl;
        if (is_oriented) {
            file << count << std::endl;
        } else {
            file << count / 2 << std::endl;
        }
        file.close();
    }
    is_edges_counted = true;
}
