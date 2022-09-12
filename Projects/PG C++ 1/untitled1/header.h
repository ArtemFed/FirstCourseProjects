#ifndef UNTITLED1_HEADER_H
#define UNTITLED1_HEADER_H

std::vector<std::vector<int>> graph_adjacency_matrix;

std::vector<std::vector<int>> graph_incidence_matrix;

std::map<int, std::set<int>> graph_adjacency_list;

std::set<std::pair<int, int>> graph_edges_list;

std::string input;

std::string output;

// true - oriented, false - not oriented
bool is_oriented = false;

// true - received
bool is_graph_received = false;

// true - Console, false - file
bool console_or_file = true;

// true - calculated
bool is_degrees_calculated = false;

// true - counted
bool is_edges_counted = false;

// 1 - Adjacency Matrix, 2 - Incidence Matrix
// 3 - Adjacency List, 4 - List Edges
int cur_graph_type = 0;


// Input
void GetGraph();

void HowInputGraph();

void ChooseActionWithGraph();

void GetIsOriented();

int GetNumberConsole(const int &left, const int &right);

int GetNumberFile(const int &left, const int &right, const int &row);


// Matrix Graphs
void GetGraphAdjacencyMatrix();

void GetGraphIncidenceMatrix();

void DisplayGraphMatrix(const size_t &row, const size_t &col, const bool &flag);

void DisplayGraphMatrixFile(const size_t &row, const size_t &col, const bool &flag);

void CalculateDegreesVerticesMatrix(const size_t &row, const size_t &col, const bool &flag);

void CalculateCountEdgesMatrix(const size_t &row, const size_t &col, const bool &flag);


// List Graphs
void GetGraphAdjacencyList();

void GetGraphListEdges();

void DisplayGraphAdjacencyList();

void DisplayGraphAdjacencyListFile();

void DisplayListEdges();

void CalculateDegreesVerticesList(const bool &flag);

void CalculateCountEdgesList(const bool &flag);

#endif //UNTITLED1_HEADER_H
