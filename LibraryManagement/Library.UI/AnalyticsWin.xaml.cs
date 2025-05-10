using LibraryManagement.Library.Repository.DataAccess;
using LibraryManagement.Library.Repository.DataAccess.LibraryDataSetTableAdapters;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using LibraryManagement.Library.Repository.Database;

namespace LibraryManagement.Library.UI
{
    public partial class AnalyticsWin : Window
    {

        public AnalyticsWin()
        {
            InitializeComponent();
            LoadPieChart();
            LoadLineChart();
            cmbTopBooksLimit.SelectionChanged += CmbTopBooksLimit_SelectionChanged;
            cmbTimePeriod.SelectionChanged += CmbTimePeriod_SelectionChanged;
        }
        private void CmbTopBooksLimit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPieChart();
        }

        private void CmbTimePeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadLineChart();
        }

        private void LoadPieChart()
        {
            try
            {
                int limit = 5;
                if (cmbTopBooksLimit.SelectedItem != null)
                {
                    limit = int.Parse((cmbTopBooksLimit.SelectedItem as ComboBoxItem).Content.ToString());
                }

                MostBorrowedTableAdapter adapter = new MostBorrowedTableAdapter();
                adapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
                LibraryDataSet.MostBorrowedDataTable dataTable = new LibraryDataSet.MostBorrowedDataTable();
                adapter.Fill(dataTable, limit);

                pieChartContainer.Children.Clear();

                if (dataTable.Rows.Count == 0)
                {
                    pieChartContainer.Children.Add(new TextBlock
                    {
                        Text = "No data available",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    return;
                }

                var pieChart = new PieChart
                {
                    Series = new SeriesCollection(),
                    LegendLocation = LegendLocation.Right
                };

                foreach (DataRow row in dataTable.Rows)
                {
                    string title = row["Title"].ToString();
                    string author = row["Author"].ToString();
                    int loanCount = Convert.ToInt32(row["LoanCount"]);

                    pieChart.Series.Add(new PieSeries
                    {
                        Title = $"{title} ({author})",
                        Values = new ChartValues<int> { loanCount },
                        DataLabels = true
                    });
                }

                pieChartContainer.Children.Add(pieChart);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pie chart: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadLineChart()
        {
            try
            {
                string timePeriod = "daily";
                if (cmbTimePeriod.SelectedItem != null)
                {
                    timePeriod = ((ComboBoxItem)cmbTimePeriod.SelectedItem).Content.ToString().ToLower();
                }

                DateTime endDate = DateTime.Now;
                DateTime startDate;
                DataTable dataTable = new DataTable();

                switch (timePeriod)
                {
                    case "weekly":
                        startDate = endDate.AddMonths(-6);
                        WeeklyStatsTableAdapter weeklyAdapter = new WeeklyStatsTableAdapter();
                        weeklyAdapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
                        dataTable = weeklyAdapter.GetData(startDate, endDate);
                        break;
                    case "monthly":
                        startDate = endDate.AddYears(-1);
                        MonthlyStatsTableAdapter monthlyAdapter = new MonthlyStatsTableAdapter();
                        monthlyAdapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
                        dataTable = monthlyAdapter.GetData(startDate, endDate);
                        break;
                    default: // daily
                        startDate = endDate.AddMonths(-1);
                        DailyStatsTableAdapter dailyAdapter = new DailyStatsTableAdapter();
                        dailyAdapter.Connection = new SqlConnection(DatabaseHelper.ConnectionString);
                        dataTable = dailyAdapter.GetData(startDate, endDate);
                        break;
                }

                lineChartContainer.Children.Clear();

                if (dataTable.Rows.Count == 0)
                {
                    lineChartContainer.Children.Add(new TextBlock
                    {
                        Text = "No data available for the selected period",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    return;
                }

                var periods = new List<string>();
                var counts = new List<int>();

                foreach (DataRow row in dataTable.Rows)
                {
                    periods.Add(row["Period"].ToString());
                    counts.Add(Convert.ToInt32(row["LoanCount"]));
                }

                var lineChart = new CartesianChart
                {
                    Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = "Books borrowed",
                            Values = new ChartValues<int>(counts)
                        }
                    },
                    AxisX = new AxesCollection
                    {
                        new Axis
                        {
                            Title = "Time Period",
                            Labels = periods
                        }
                    },
                    AxisY = new AxesCollection
                    {
                        new Axis
                        {
                            Title = "Number of Books",
                            LabelFormatter = value => value.ToString("N0")
                        }
                    },
                    LegendLocation = LegendLocation.Top
                };

                lineChartContainer.Children.Add(lineChart);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading line chart: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}