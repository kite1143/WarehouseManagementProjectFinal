document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('myChart1').getContext('2d');

    // Fetch data from the controller's action
    fetch('/Home/GetOrderQuantityByCategory')
        .then(response => response.json())
        .then(data => {
            const categories = data.data.map(item => item.categoryName);
            const quantities = data.data.map(item => item.totalQuantity);

            // Create the bar chart
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: categories,
                    datasets: [{
                        label: 'Quantity by Category',
                        data: quantities,
                        backgroundColor: 'rgba(153, 102, 255, 0.2)',
                        borderColor: 'rgb(153, 102, 255)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('myChart2').getContext('2d');

    // Fetch data from the controller's action
    fetch('/Home/GetReceivingQuantityByCategory')
        .then(response => response.json())
        .then(data => {
            const categories = data.data.map(item => item.categoryName);
            const quantities = data.data.map(item => item.totalQuantity);

            // Create the bar chart
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: categories,
                    datasets: [{
                        label: 'Quantity by Category',
                        data: quantities,
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgb(255, 99, 132)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('myChart3').getContext('2d');

    // Fetch data from the controller's action
    fetch('/Home/GetInventoryQuantityByCategory')
        .then(response => response.json())
        .then(data => {
            const categories = data.data.map(item => item.categoryName);
            const quantities = data.data.map(item => item.totalQuantity);

            // Create the bar chart
            new Chart(ctx, {
                type: 'polarArea',
                data: {
                    labels: categories,
                    datasets: [{
                        label: 'Quantity by Category',
                        data: quantities,
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('myChart4').getContext('2d');

    // Fetch data from the controller's action
    fetch('/Home/GetNumberOfOrderByStatus')
        .then(response => response.json())
        .then(data => {
            const categories = data.data.map(item => item.status);
            const quantities = data.data.map(item => item.numberOfOrders);

            // Create the bar chart
            new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: categories,
                    datasets: [{
                        label: 'Numbers By Status',
                        data: quantities,
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
});


var dataTable;
$(document).ready(function () {
    loadLastestOrderTable();
    loadLastestReceivingTable();
})
function loadLastestOrderTable() {
    dataTable = $('#lastestOrderTable').DataTable({
        "ajax": { url: '/Home/GetLastestOrders' },
        "columns": [
            { data: 'orderDate' },
            { data: 'customer.customerName' },
            { data: 'status' },
            { data: 'totalAmount' },
        ],
        searching: false,
        ordering: false,
        paging: false
    });
}

function loadLastestReceivingTable() {
    dataTable = $('#lastestReceivingTable').DataTable({
        "ajax": { url: '/Home/GetLastestReceivings' },
        "columns": [
            { data: 'receivingDate' },
            { data: 'supplier.supplierName' },
            { data: 'warehouse.warehouseName' },
        ],
        searching: false,
        ordering: false,
        paging: false
    });
}