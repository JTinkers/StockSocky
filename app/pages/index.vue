<template>
	<v-container fluid>
		<v-row justify='end'>
			<v-col cols='4'>
				<v-text-field v-model='search' outlined placeholder='Search..'/>
			</v-col>
		</v-row>
		<v-row>
			<v-col cols='12'>
				<v-data-table hide-default-footer :search='search' :items='stocks' :headers='headers'>
					<template #item.estimatedProfit='{ item, value }'>
						<span :class='{ "value-positive": value > 0, "value-negative": value < 0 }' v-text='value'/>
					</template>
					<template #item.estimatedProfitPercentage='{ item, value }'>
						<span :class='{ "value-positive": value > 0, "value-negative": value < 0 }' v-text='value + "%"'/>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
		<v-row>
			<span v-text='"crud for stocks here"'/>
		</v-row>
	</v-container>
</template>

<script>
	export default
	{
		data: () =>
		({
			search: null,
			stocks: []
		}),
		mounted()
		{
			this.fetch()
			this.openSocket()
		},
		computed:
		{
			headers()
			{
				var headers =
				[
					{
						text: 'Name',
						value: 'name'
					},
					{
						text: 'Symbol',
						value: 'symbol'
					},
					{
						text: 'Quantity',
						value: 'quantity'
					},
					{
						text: 'Invested Value',
						value: 'investedValue'
					},
					{
						text: 'Market Value',
						value: 'marketValue'
					},
					{
						text: 'Est. Profit',
						value: 'estimatedProfit'
					},
					{
						text: 'Est. Profit (%)',
						value: 'estimatedProfitPercentage'
					},
					{
						text: 'Last Update',
						value: 'lastUpdate'
					}
				]

				return headers
			}
		},
		methods:
		{
			async openSocket()
			{
				var socket = new WebSocket('wss://ws.finnhub.io?token=brjhto7rh5r9g3ot4erg')

				socket.onopen = () =>
				{
					var symbols = this.stocks.map(x => x.symbol)

					symbols.forEach(x => socket.send(JSON.stringify(
					{
						type: 'subscribe',
						symbol: x
					})))
				}

				socket.onmessage = (e) =>
				{
					// show notification on error
					var result = JSON.parse(e.data)

					if(result.type == "trade")
					{
						result.data.forEach(data =>
						{
							var stock = this.stocks.find(x => x.symbol == data.s)

							if(!stock)
								return

							stock.marketValue = data.p.toFixed(2)
							stock.estimatedProfit = ((stock.marketValue * stock.quantity) - stock.investedValue).toFixed(2)
							stock.estimatedProfitPercentage = ((stock.estimatedProfit / stock.investedValue) * 100).toFixed(2)
							stock.lastUpdate = this.$moment(data.t).fromNow()
						})
					}
				}
			},
			async fetch()
			{
				var { data } = await this.$axios.get('/api/stocks')

				this.stocks = data

				// set placeholders for virtual columns
				this.stocks.forEach(x => this.$set(x, 'marketValue', 0))
				this.stocks.forEach(x => this.$set(x, 'estimatedProfit', 0))
				this.stocks.forEach(x => this.$set(x, 'estimatedProfitPercentage', 0))
				this.stocks.forEach(x => this.$set(x, 'lastUpdate', null))
			}
		}
	}
</script>

<style lang='scss' scoped>
	.value-positive
	{
		padding: 4px 8px;
		border-radius: 3px;
		background: palette('green');
		color: white;
	}

	.value-negative
	{
		padding: 4px 8px;
		border-radius: 3px;
		background: palette('red');
		color: white;
	}
</style>
