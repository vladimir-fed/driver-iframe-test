const html = `
<html>
	<head>
		<title>Test driver</title>
	</head>
	<body>
		<iframe id="inlineFrameExample"
			title="Inline Frame Example"
			width="300"
			height="200"
			src='/frame/page/10'>
		</iframe>
		<button id='refreshFrame' onclick="document.querySelector('#inlineFrameExample').setAttribute('src', '/frame/page/' + window.number++)">Refresh</button>
	</body>
	<script>
		window.number = 11;
	</script>
</html>
`;

const iframeHtml = (current) => `
<html>
	<head>
		<title>
			Frame
		</title>
		<script>
			function reloadWith(i) {
				window.location.href = '/frame/page/' + i;
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

const requestListener = (req, res) => {
	const match = req.url.match(/\/page\/(\d+)/);

	if (!match || !match[1]) {
		res.writeHead(200, { "Content-Type": "text/html" });
		res.write(html);
		return res.end();
	}

	// setTimeout(() => {
		const index = +match[1];
		res.write(iframeHtml(index));
		res.end();
	// }, 100);
};

module.exports = {
	requestListener
}