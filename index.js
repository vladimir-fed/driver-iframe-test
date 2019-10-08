const { createServer } = require('http');
const { readFile } = require('fs');

const port = +process.env.PORT || 9999;

const iframeHtml = (current) => `
<html>
	<head>
		<title>
			Frame
		</title>
		<script>
			function reloadWith(i) {
				window.location.href = '/page/' + i;
			}
		</script>
	</head>
	<body>
		<button id='prev' onclick="reloadWith(${current - 1})">-1</button>
		<button id='next' onclick="reloadWith(${current + 1})">+1</button>
		<p id='valueToRead'>${current}</p>
	</body>
</html>
`;

readFile('./index.html', (err, html) => {
	if (err) {
		throw err;
	}

	const requestListener = (req, res) => {
		const match = req.url.match(/\/page\/(\d+)/);

		if (!match || !match[1]) {
			res.writeHeader(200, { "Content-Type": "text/html" });
			res.write(html);
			return res.end();
		}

		setTimeout(() => {
			const index = +match[1];
			res.write(iframeHtml(index));
			res.end();
		}, 3000);
	};

	createServer(requestListener)
		.listen(port, null, () => console.log(`Server listening on port: ${port}`));
});

